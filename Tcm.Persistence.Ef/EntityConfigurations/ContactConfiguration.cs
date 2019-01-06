using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcm.Domain.Model;

namespace Tcm.Persistence.Ef.EntityConfigurations
{
    public class ContactConfiguration<T> where T: class 
    {
        public ContactConfiguration(ReferenceOwnershipBuilder<T,Information> builder)
        {
            builder.Property(z => z.Address).HasColumnName("Address");
            builder.Property(z => z.BirthDate).HasColumnName("BirthDate");
            builder.Property(z => z.FirstName).HasColumnName("FirstName");
            builder.Property(z => z.LastName).HasColumnName("LastName");
            builder.Property(z => z.MobileNumber).HasColumnName("MobileNumber");
            builder.Property(z => z.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(z => z.PostalCode).HasColumnName("PostalCode");
            builder.Property(z => z.NationalCode).HasColumnName("NationalCode");
            builder.Property(z => z.CityId).HasColumnName("CityId");



        }
    }
}