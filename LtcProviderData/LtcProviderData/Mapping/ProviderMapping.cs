using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtcProviderData.Data;
using System.Data.Entity.ModelConfiguration;

namespace LtcProviderData.Mapping
{
    public class ProviderMapping : EntityTypeConfiguration<Provider>
    {
        public ProviderMapping()
        {
            HasKey(p => p.ID);
            Property(p => p.CCN).IsRequired();
            Property(p => p.Comment);
        }
    }
}