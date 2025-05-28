using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.ComponentModel.DataAnnotations; // en üste
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class AddEntityForm : Form
    {
        private Type entityType;
        private Dictionary<string, TextBox> fieldInputs = new Dictionary<string, TextBox>();

        public AddEntityForm(Type type)
        {
            InitializeComponent();
            entityType = type;
            CreateDynamicForm();
        }

        private void CreateDynamicForm()
        {
            var properties = entityType.GetProperties()
            .Where(p =>
                p.CanWrite &&
                p.GetCustomAttribute<KeyAttribute>() == null &&
                (p.PropertyType.IsPrimitive || p.PropertyType == typeof(string) || Nullable.GetUnderlyingType(p.PropertyType) != null)
            );


            int y = 20;
            foreach (var prop in properties)
            {
                Label label = new Label
                {
                    Text = prop.Name,
                    Location = new Point(10, y),
                    AutoSize = true
                };
                TextBox textBox = new TextBox
                {
                    Location = new Point(120, y),
                    Width = 150
                };

                this.Controls.Add(label);
                this.Controls.Add(textBox);
                fieldInputs[prop.Name] = textBox;

                y += 30;
            }

            Button btnSave = new Button
            {
                Text = "Save",
                Location = new Point(120, y)
            };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            this.Height = y + 80;
            this.Width = 300;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            object instance = Activator.CreateInstance(entityType);

            foreach (var entry in fieldInputs)
            {
                var prop = entityType.GetProperty(entry.Key);
                if (prop != null)
                {
                    try
                    {
                        string input = entry.Value.Text;
                        Type targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                        object value = string.IsNullOrWhiteSpace(input)
                            ? null
                            : Convert.ChangeType(input, targetType);

                        prop.SetValue(instance, value);
                    }
                    catch
                    {
                        MessageBox.Show($"Invalid input for {prop.Name}");
                        return;
                    }
                }
            }

            var context = new ValidationContext(instance);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(instance, context, results, true);

            if (!isValid)
            {
                string errorMessages = string.Join("\n", results.Select(r => r.ErrorMessage));
                MessageBox.Show("Validation failed:\n" + errorMessages);
                return;
            }

            try
            {
                using (var db = new HotelManagementSystemEntities1())
                {
                    db.Set(entityType).Add(instance);
                    db.SaveChanges();
                }

                MessageBox.Show("Saved successfully!");
                this.Close();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Database update failed. Possible primary key violation.\n\n" + ex.InnerException?.InnerException?.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred:\n" + ex.Message);
            }

        }
    }
}
