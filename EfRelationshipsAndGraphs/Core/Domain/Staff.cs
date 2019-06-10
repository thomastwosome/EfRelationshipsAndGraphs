namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class Staff
    {
        public int StaffId { get; set; }

        public string StaffName { get; set; }

        /* Navigational Properties */

        public int MoeId { get; set; }
        public Exemption Exemption { get; set; }

    }
}