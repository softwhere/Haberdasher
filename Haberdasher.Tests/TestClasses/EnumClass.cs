using Haberdasher.Attributes;

namespace Haberdasher.Tests.TestClasses
{
	public class EnumClass
	{
        public enum ApprovalStatus 
        {
            Proposed = 0,

            Approved = 1,

            Rejected = 2
        }

		[Key]
		public int Id { get; set; }

		public string Name { get; set; }

        public ApprovalStatus Status { get; set; }
	}
}
