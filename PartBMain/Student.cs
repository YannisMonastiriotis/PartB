//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PartBMain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Payments = new HashSet<Payment>();
        }
    
        public int StudentID { get; set; }
        public string Tuition__Fees { get; set; }
        public int PersonID { get; set; }
        public Nullable<double> SignupNo { get; set; }
    
        public virtual Person Person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        public override string ToString()
        {
            return $"\n ID: {StudentID} Tuition Fees : {Tuition__Fees} First Name: {Person.FirstName} Last Name: {Person.LastName} \n \n  SignupNo: {SignupNo} ";
        }
    }
}