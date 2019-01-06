using Framework.Persistence.Ef;

namespace Tcm.Domain.Model
{
    public class User : EntityBase<long>
    {

        public string Email { get; set; }
    }
}
