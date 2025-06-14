//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservation()
        {
            this.Employees = new HashSet<Employee>();
        }
    
        public int ReservationID { get; set; }
        public string ReservationStatus { get; set; }
        public Nullable<int> NumberOfPeople { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> PaymentID { get; set; }
        public Nullable<int> RoomID { get; set; }
        public Nullable<int> CustomerID { get; set; }
    
        public virtual Feedback Feedback { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Room Room { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
