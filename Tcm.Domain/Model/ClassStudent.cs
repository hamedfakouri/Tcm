using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class ClassStudent : EntityBase<long>
    {
        public long  StudentId { get; set; }
        public Student Student { get; set; }
        public long ClassRoomId { get; set; }
        public ClassRoom ClassRoom{ get; set; }
        public short Year { get; set; }
    }
    
}
