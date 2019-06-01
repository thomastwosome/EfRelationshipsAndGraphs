namespace EfRelationshipsAndGraphs.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        /* Navigational Properties */

        public int MoeId { get; set; }
        public Exemption Exemption { get; set; }

    }
}