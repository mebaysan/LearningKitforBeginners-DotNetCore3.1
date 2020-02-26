using System.Collections.Generic;
using CoreMVCFundamentals.Models;

namespace CoreMVCFundamentals.ViewModels
{
    public class CourseStudentViewModel
    {
        public Course Course { get; set; }
        public List<Student> Students { get; set; }
    }
}