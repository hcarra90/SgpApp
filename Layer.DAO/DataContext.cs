using System.Data.Entity;
using Layer.Entity;

namespace Layer.DAO
{
    public class DataContext : DbContext
    {
        #region Constructores
        public DataContext() : base("name=DataContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        #endregion

        #region Declaración
        
        #region Clases Usuario
        DbSet<Usuario> usuario;
        public DbSet<Usuario> Usuario
        {
            get
            {
                if (usuario == null)
                    usuario = base.Set<Usuario>();
                return usuario;
            }
        }

        DbSet<Perfil> perfil;
        public DbSet<Perfil> Perfil
        {
            get
            {
                if (perfil == null)
                    perfil = base.Set<Perfil>();
                return perfil;
            }
        }

        #endregion

        #region Clases Maestros

        DbSet<InfoFieldBook> infoFieldBook;
        public DbSet<InfoFieldBook> InfoFieldBook
        {
            get
            {
                if (infoFieldBook == null)
                    infoFieldBook = base.Set<InfoFieldBook>();
                return infoFieldBook;
            }
        }

        DbSet<InfoDryers> infoDryers;
        public DbSet<InfoDryers> InfoDryers
        {
            get
            {
                if (infoDryers == null)
                    infoDryers = base.Set<InfoDryers>();
                return infoDryers;
            }
        }

        DbSet<InfoShipping> infoShipping;
        public DbSet<InfoShipping> InfoShipping
        {
            get
            {
                if (infoShipping == null)
                    infoShipping = base.Set<InfoShipping>();
                return infoShipping;
            }
        }

        DbSet<Parametro> parametro;
        public DbSet<Parametro> Parametro
        {
            get
            {
                if (parametro == null)
                    parametro = base.Set<Parametro>();
                return parametro;
            }
        }

        DbSet<Email> email;
        public DbSet<Email> Email
        {
            get
            {
                if (email == null)
                    email = base.Set<Email>();
                return email;
            }
        }

        DbSet<Shipment> shipment;
        public DbSet<Shipment> Shipment
        {
            get
            {
                if (shipment == null)
                    shipment = base.Set<Shipment>();
                return shipment;
            }
        }

        DbSet<DiscardReason> discardReason;
        public DbSet<DiscardReason> DiscardReason
        {
            get
            {
                if (discardReason == null)
                    discardReason = base.Set<DiscardReason>();
                return discardReason;
            }
        }

        DbSet<EntryList> entryList;
        public DbSet<EntryList> EntryList
        {
            get
            {
                if (entryList == null)
                    entryList = base.Set<EntryList>();
                return entryList;
            }
        }

        DbSet<InfoFarm> infoFarm;
        public DbSet<InfoFarm> InfoFarm
        {
            get
            {
                if (infoFarm == null)
                    infoFarm = base.Set<InfoFarm>();
                return infoFarm;
            }
        }

        DbSet<InfoLoc> infoLoc;
        public DbSet<InfoLoc> InfoLoc
        {
            get
            {
                if (infoLoc == null)
                    infoLoc = base.Set<InfoLoc>();
                return infoLoc;
            }
        }

        DbSet<CentroCostoExperimento> centroCostoExperimento;
        public DbSet<CentroCostoExperimento> CentroCostoExperimento
        {
            get
            {
                if (centroCostoExperimento == null)
                    centroCostoExperimento = base.Set<CentroCostoExperimento>();
                return centroCostoExperimento;
            }
        }

        DbSet<CentroCosto> centroCosto;
        public DbSet<CentroCosto> CentroCosto
        {
            get
            {
                if (centroCosto == null)
                    centroCosto = base.Set<CentroCosto>();
                return centroCosto;
            }
        }

        DbSet<Cliente> cliente;
        public DbSet<Cliente> Cliente
        {
            get
            {
                if (cliente == null)
                    cliente = base.Set<Cliente>();
                return cliente;
            }
        }

        DbSet<Crop> crop;
        public DbSet<Crop> Crop
        {
            get
            {
                if (crop == null)
                    crop = base.Set<Crop>();
                return crop;
            }
        }

        DbSet<Empresa> empresa;
        public DbSet<Empresa> Empresa
        {
            get
            {
                if (empresa == null)
                    empresa = base.Set<Empresa>();
                return empresa;
            }
        }

        DbSet<Estado> estado;
        public DbSet<Estado> Estado
        {
            get
            {
                if (estado == null)
                    estado = base.Set<Estado>();
                return estado;
            }
        }

        DbSet<Project> project;
        public DbSet<Project> Project
        {
            get
            {
                if (project == null)
                    project = base.Set<Project>();
                return project;
            }
        }

        DbSet<Region> region;
        public DbSet<Region> Region
        {
            get
            {
                if (region == null)
                    region = base.Set<Region>();
                return region;
            }
        }

        DbSet<TipoAgro> tipoAgro;
        public DbSet<TipoAgro> TipoAgro
        {
            get
            {
                if (tipoAgro == null)
                    tipoAgro = base.Set<TipoAgro>();
                return tipoAgro;
            }
        }

        DbSet<TipoContrato> tipoContrato;
        public DbSet<TipoContrato> TipoContrato
        {
            get
            {
                if (tipoContrato == null)
                    tipoContrato = base.Set<TipoContrato>();
                return tipoContrato;
            }
        }

        DbSet<Nota> nota;
        public DbSet<Nota> Nota
        {
            get
            {
                if (nota == null)
                    nota = base.Set<Nota>();
                return nota;
            }
        }

        DbSet<Pallet> pallet;
        public DbSet<Pallet> Pallet
        {
            get
            {
                if (pallet == null)
                    pallet = base.Set<Pallet>();
                return pallet;
            }
        }

        #endregion

        #region Clases de auditoria

        #endregion

        #region Clases Dominios

        DbSet<MovimientoPacking> movimientoPacking;
        public DbSet<MovimientoPacking> MovimientoPacking
        {
            get
            {
                if (movimientoPacking == null)
                    movimientoPacking = base.Set<MovimientoPacking>();
                return movimientoPacking;
            }
        }

        DbSet<MovimientoShipping> movimientoShipping;
        public DbSet<MovimientoShipping> MovimientoShipping
        {
            get
            {
                if (movimientoShipping == null)
                    movimientoShipping = base.Set<MovimientoShipping>();
                return movimientoShipping;
            }
        }

        DbSet<MovimientoCaja> movimientoCaja;
        public DbSet<MovimientoCaja> MovimientoCaja
        {
            get
            {
                if (movimientoCaja == null)
                    movimientoCaja = base.Set<MovimientoCaja>();
                return movimientoCaja;
            }
        }

        DbSet<MovimientoCosecha> movimientoCosecha;
        public DbSet<MovimientoCosecha> MovimientoCosecha
        {
            get
            {
                if (movimientoCosecha == null)
                    movimientoCosecha = base.Set<MovimientoCosecha>();
                return movimientoCosecha;
            }
        }

        DbSet<MovimientoSecado> movimientoSecado;
        public DbSet<MovimientoSecado> MovimientoSecado
        {
            get
            {
                if (movimientoSecado == null)
                    movimientoSecado = base.Set<MovimientoSecado>();
                return movimientoSecado;
            }
        }

        DbSet<MovimientoDesgrane> movimientoDesgrane;
        public DbSet<MovimientoDesgrane> MovimientoDesgrane
        {
            get
            {
                if (movimientoDesgrane == null)
                    movimientoDesgrane = base.Set<MovimientoDesgrane>();
                return movimientoDesgrane;
            }
        }

        DbSet<MovimientoRogging> movimientoRogging;
        public DbSet<MovimientoRogging> MovimientoRogging
        {
            get
            {
                if (movimientoRogging == null)
                    movimientoRogging = base.Set<MovimientoRogging>();
                return movimientoRogging;
            }
        }

        DbSet<MovimientoNota> movimientoNota;
        public DbSet<MovimientoNota> MovimientoNota
        {
            get
            {
                if (movimientoNota == null)
                    movimientoNota = base.Set<MovimientoNota>();
                return movimientoNota;
            }
        }

        DbSet<ProgramaExport> programaExport;
        public DbSet<ProgramaExport> ProgramaExport
        {
            get
            {
                if (programaExport == null)
                    programaExport = base.Set<ProgramaExport>();
                return programaExport;
            }
        }

        DbSet<MovimientoDespacho> movimientoDespacho;
        public DbSet<MovimientoDespacho> MovimientoDespacho
        {
            get
            {
                if (movimientoDespacho == null)
                    movimientoDespacho = base.Set<MovimientoDespacho>();
                return movimientoDespacho;
            }
        }
        #endregion

        #endregion

        #region Métodos Sobreescritos
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Mapeo tablas de Usuarios
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Perfil>().ToTable("Perfil");
            modelBuilder.Entity<InfoFieldBook>().ToTable("InfoFieldBook");
            modelBuilder.Entity<InfoShipping>().ToTable("InfoShipping");
            modelBuilder.Entity<InfoDryers>().ToTable("InfoDryers");
            modelBuilder.Entity<InfoFarm>().ToTable("InfoFarm");
            modelBuilder.Entity<InfoLoc>().ToTable("InfoLoc");
            modelBuilder.Entity<CentroCostoExperimento>().ToTable("InfoCCExp");
            modelBuilder.Entity<MovimientoPacking>().ToTable("MovimientoPacking");
            modelBuilder.Entity<MovimientoShipping>().ToTable("MovimientoShipping");
            modelBuilder.Entity<MovimientoCaja>().ToTable("MovimientoCaja");
            modelBuilder.Entity<MovimientoCosecha>().ToTable("MovimientoCosecha");
            modelBuilder.Entity<MovimientoDesgrane>().ToTable("MovimientoDesgrane");
            modelBuilder.Entity<MovimientoSecado>().ToTable("MovimientoSecado");
            modelBuilder.Entity<Parametro>().ToTable("Parametro");
            modelBuilder.Entity<Email>().ToTable("Email");
            modelBuilder.Entity<Shipment>().ToTable("Shipment");
            modelBuilder.Entity<DiscardReason>().ToTable("DiscardReason");
            modelBuilder.Entity<MovimientoRogging>().ToTable("MovimientoRogging");
            modelBuilder.Entity<EntryList>().ToTable("EntryList");
            modelBuilder.Entity<CentroCosto>().ToTable("CentroCosto");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Crop>().ToTable("Crop");
            modelBuilder.Entity<Empresa>().ToTable("Empresa");
            modelBuilder.Entity<Estado>().ToTable("Estado");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Region>().ToTable("Region");
            modelBuilder.Entity<TipoAgro>().ToTable("TipoAgro");
            modelBuilder.Entity<TipoContrato>().ToTable("TipoContrato");
            modelBuilder.Entity<Nota>().ToTable("Nota");
            modelBuilder.Entity<MovimientoNota>().ToTable("MovimientoNota");
            modelBuilder.Entity<ProgramaExport>().ToTable("ProgramaExport");
            modelBuilder.Entity<MovimientoDespacho>().ToTable("MovimientoDespacho");
            modelBuilder.Entity<Pallet>().ToTable("Pallet");
            #endregion

            #region Relaciones Clases
            //InfoFarm
            modelBuilder.Entity<InfoFarm>()
                    .HasRequired(c => c.Empresa)
                    .WithMany()
                    .HasForeignKey(t => t.id_empresa).WillCascadeOnDelete(false);

            modelBuilder.Entity<InfoFarm>()
                    .HasRequired(c => c.Region)
                    .WithMany()
                    .HasForeignKey(t => t.id_region).WillCascadeOnDelete(false);

            modelBuilder.Entity<InfoFarm>()
                    .HasRequired(c => c.TipoContrato)
                    .WithMany()
                    .HasForeignKey(t => t.id_tipo_contrato).WillCascadeOnDelete(false);

            modelBuilder.Entity<InfoFarm>()
                    .HasRequired(c => c.Estado)
                    .WithMany()
                    .HasForeignKey(t => t.id_estado).WillCascadeOnDelete(false);

            //InfoLoc
            modelBuilder.Entity<InfoLoc>()
                    .HasRequired(c => c.InfoFarm)
                    .WithMany()
                    .HasForeignKey(t => t.id_farm).WillCascadeOnDelete(false);

            modelBuilder.Entity<InfoLoc>()
                    .HasRequired(c => c.Crop)
                    .WithMany()
                    .HasForeignKey(t => t.id_crop).WillCascadeOnDelete(false);

            modelBuilder.Entity<InfoLoc>()
                    .HasRequired(c => c.TipoAgro)
                    .WithMany()
                    .HasForeignKey(t => t.id_tipo_agro).WillCascadeOnDelete(false);

            modelBuilder.Entity<InfoLoc>()
                    .HasRequired(c => c.Estado)
                    .WithMany()
                    .HasForeignKey(t => t.id_estado).WillCascadeOnDelete(false);

            modelBuilder.Entity<Pallet>()
                    .HasRequired(c => c.Empresa)
                    .WithMany()
                    .HasForeignKey(t => t.id_empresa).WillCascadeOnDelete(false);

            //InfoCCExp
            modelBuilder.Entity<CentroCostoExperimento>()
                    .HasRequired(c => c.Crop)
                    .WithMany()
                    .HasForeignKey(t => t.id_crop).WillCascadeOnDelete(false);

            modelBuilder.Entity<CentroCostoExperimento>()
                    .HasRequired(c => c.Estado)
                    .WithMany()
                    .HasForeignKey(t => t.id_estado).WillCascadeOnDelete(false);

            modelBuilder.Entity<CentroCostoExperimento>()
                    .HasRequired(c => c.TipoAgro)
                    .WithMany()
                    .HasForeignKey(t => t.id_tipo_agro).WillCascadeOnDelete(false);

            modelBuilder.Entity<CentroCostoExperimento>()
                    .HasRequired(c => c.InfoLoc)
                    .WithMany()
                    .HasForeignKey(t => t.id_location).WillCascadeOnDelete(false);

            //CentroCosto
            modelBuilder.Entity<CentroCosto>()
                    .HasRequired(c => c.Empresa)
                    .WithMany()
                    .HasForeignKey(t => t.id_empresa).WillCascadeOnDelete(false);

            //Cliente
            modelBuilder.Entity<Cliente>()
                    .HasRequired(c => c.Empresa)
                    .WithMany()
                    .HasForeignKey(t => t.id_empresa).WillCascadeOnDelete(false);

            //Crop
            modelBuilder.Entity<Crop>()
                    .HasRequired(c => c.Empresa)
                    .WithMany()
                    .HasForeignKey(t => t.id_empresa).WillCascadeOnDelete(false);

            //Estado
            modelBuilder.Entity<Estado>()
                    .HasRequired(c => c.Empresa)
                    .WithMany()
                    .HasForeignKey(t => t.id_empresa).WillCascadeOnDelete(false);

            //Project
            modelBuilder.Entity<Project>()
                    .HasRequired(c => c.Empresa)
                    .WithMany()
                    .HasForeignKey(t => t.id_empresa).WillCascadeOnDelete(false);

            //Region
            modelBuilder.Entity<Region>()
                    .HasRequired(c => c.Empresa)
                    .WithMany()
                    .HasForeignKey(t => t.id_empresa).WillCascadeOnDelete(false);

            //TipoAgro
            modelBuilder.Entity<TipoAgro>()
                    .HasRequired(c => c.Empresa)
                    .WithMany()
                    .HasForeignKey(t => t.id_empresa).WillCascadeOnDelete(false);

            //TipoContrato
            modelBuilder.Entity<TipoContrato>()
                    .HasRequired(c => c.Empresa)
                    .WithMany()
                    .HasForeignKey(t => t.id_empresa).WillCascadeOnDelete(false);

            //Nota
            modelBuilder.Entity<Nota>()
                    .HasRequired(c => c.Empresa)
                    .WithMany()
                    .HasForeignKey(t => t.id_empresa).WillCascadeOnDelete(false);

            //Nota
            modelBuilder.Entity<MovimientoNota>()
                    .HasRequired(c => c.Nota)
                    .WithMany()
                    .HasForeignKey(t => t.id_nota).WillCascadeOnDelete(false);

            modelBuilder.Entity<ProgramaExport>()
                    .HasRequired(c => c.Empresa)
                    .WithMany()
                    .HasForeignKey(t => t.id_empresa).WillCascadeOnDelete(false);
            #endregion
        }
        #endregion
    }
}
