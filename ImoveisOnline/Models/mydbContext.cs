using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ImoveisOnline.Models
{
    public partial class mydbContext : DbContext
    {
        public mydbContext()
        {
        }

        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendamento> Agendamentos { get; set; }
        public virtual DbSet<AnuncioImovel> AnuncioImovels { get; set; }
        public virtual DbSet<DetalhesDoLocal> DetalhesDoLocals { get; set; }
        public virtual DbSet<DetalhesImovel> DetalhesImovels { get; set; }
        public virtual DbSet<DetalhesLocacao> DetalhesLocacaos { get; set; }
        public virtual DbSet<DetalhesVendum> DetalhesVenda { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioRole> UsuarioRoles { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseMySql("server=localhost;port=3306;database=mydb;uid=root;password=P@tr1c1a26L30M@R", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.33-mysql"));
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.ToTable("agendamento");

                entity.HasIndex(e => e.DetalhesImovelId, "fk_AGENDAMENTO_DETALHES_IMOVEL1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DetalhesImovelId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DETALHES_IMOVEL_ID");

                entity.Property(e => e.DiaEHora)
                    .HasColumnType("datetime")
                    .HasColumnName("DIA_E_HORA");

                entity.Property(e => e.Lebretes)
                    .HasMaxLength(45)
                    .HasColumnName("LEBRETES");

                entity.HasOne(d => d.DetalhesImovel)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.DetalhesImovelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AGENDAMENTO_DETALHES_IMOVEL1");
            });

            modelBuilder.Entity<AnuncioImovel>(entity =>
            {
                entity.ToTable("anuncio_imovel");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Dia)
                    .HasColumnType("datetime")
                    .HasColumnName("DIA");

                entity.Property(e => e.Preco)
                    .HasPrecision(10)
                    .HasColumnName("PRECO");
            });

            modelBuilder.Entity<DetalhesDoLocal>(entity =>
            {
                entity.ToTable("detalhes_do_local");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Academia)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("ACADEMIA");

                entity.Property(e => e.Garagem)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("GARAGEM");
            });

            modelBuilder.Entity<DetalhesImovel>(entity =>
            {
                entity.ToTable("detalhes_imovel");

                entity.HasIndex(e => e.DetalhesDoLocalId, "fk_DETALHES_IMOVEL_DETALHES_DO_LOCAL1_idx");

                entity.HasIndex(e => e.EnderecoId, "fk_DETALHES_IMOVEL_ENDERECO_idx");

                entity.HasIndex(e => e.UsuarioId, "fk_DETALHES_IMOVEL_USUARIO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(45)
                    .HasColumnName("DESCRICAO");

                entity.Property(e => e.DetalhesDoLocalId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DETALHES_DO_LOCAL_ID");

                entity.Property(e => e.DetalhesImovel1)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("DETALHES_IMOVEL");

                entity.Property(e => e.EnderecoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ENDERECO_ID");

                entity.Property(e => e.Mobiliado)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("MOBILIADO");

                entity.Property(e => e.MoradorAtual)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("MORADOR_ATUAL");

                entity.Property(e => e.NumeroBanheiros)
                    .HasColumnType("int(11)")
                    .HasColumnName("NUMERO_BANHEIROS");

                entity.Property(e => e.NumeroSalas)
                    .HasColumnType("int(11)")
                    .HasColumnName("NUMERO_SALAS");

                entity.Property(e => e.Pets)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("PETS");

                entity.Property(e => e.Suites)
                    .HasColumnType("int(11)")
                    .HasColumnName("SUITES");

                entity.Property(e => e.Tamanho)
                    .HasPrecision(10)
                    .HasColumnName("TAMANHO");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("TIPO");

                entity.Property(e => e.UsuarioId)
                    .HasColumnType("int(11)")
                    .HasColumnName("USUARIO_ID");

                entity.Property(e => e.ValorImovel)
                    .HasPrecision(10)
                    .HasColumnName("VALOR_IMOVEL");

                entity.HasOne(d => d.DetalhesDoLocal)
                    .WithMany(p => p.DetalhesImovels)
                    .HasForeignKey(d => d.DetalhesDoLocalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DETALHES_IMOVEL_DETALHES_DO_LOCAL1");

                entity.HasOne(d => d.Endereco)
                    .WithMany(p => p.DetalhesImovels)
                    .HasForeignKey(d => d.EnderecoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DETALHES_IMOVEL_ENDERECO");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.DetalhesImovels)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DETALHES_IMOVEL_USUARIO1");
            });

            modelBuilder.Entity<DetalhesLocacao>(entity =>
            {
                entity.ToTable("detalhes_locacao");

                entity.HasIndex(e => e.AnuncioImovelId, "fk_DETALHES_LOCACAO_ANUNCIO_IMOVEL1_idx");

                entity.HasIndex(e => e.DetalhesImovelId, "fk_DETALHES_LOCACAO_DETALHES_IMOVEL1_idx");

                entity.HasIndex(e => e.UsuarioId, "fk_DETALHES_LOCACAO_USUARIO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.AnuncioImovelId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ANUNCIO_IMOVEL_ID");

                entity.Property(e => e.DataFinalLocacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_FINAL_LOCACAO");

                entity.Property(e => e.DataInicialLocacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_INICIAL_LOCACAO");

                entity.Property(e => e.DataLocacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_LOCACAO");

                entity.Property(e => e.DetalhesImovelId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DETALHES_IMOVEL_ID");

                entity.Property(e => e.StatusAluguel)
                    .HasColumnType("int(11)")
                    .HasColumnName("STATUS_ALUGUEL");

                entity.Property(e => e.TermosDeUso)
                    .HasColumnType("int(11)")
                    .HasColumnName("TERMOS_DE_USO");

                entity.Property(e => e.UsuarioId)
                    .HasColumnType("int(11)")
                    .HasColumnName("USUARIO_ID");

                entity.Property(e => e.ValorAluguel)
                    .HasPrecision(10)
                    .HasColumnName("VALOR_ALUGUEL");

                entity.HasOne(d => d.AnuncioImovel)
                    .WithMany(p => p.DetalhesLocacaos)
                    .HasForeignKey(d => d.AnuncioImovelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DETALHES_LOCACAO_ANUNCIO_IMOVEL1");

                entity.HasOne(d => d.DetalhesImovel)
                    .WithMany(p => p.DetalhesLocacaos)
                    .HasForeignKey(d => d.DetalhesImovelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DETALHES_LOCACAO_DETALHES_IMOVEL1");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.DetalhesLocacaos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DETALHES_LOCACAO_USUARIO1");
            });

            modelBuilder.Entity<DetalhesVendum>(entity =>
            {
                entity.ToTable("detalhes_venda");

                entity.HasIndex(e => e.AnuncioImovelId, "fk_DETALHES_VENDA_ANUNCIO_IMOVEL1_idx");

                entity.HasIndex(e => e.DetalhesDoLocalId, "fk_DETALHES_VENDA_DETALHES_DO_LOCAL1_idx");

                entity.HasIndex(e => e.DetalhesImovelId, "fk_DETALHES_VENDA_DETALHES_IMOVEL1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.AnuncioImovelId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ANUNCIO_IMOVEL_ID");

                entity.Property(e => e.DataVenda)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_VENDA");

                entity.Property(e => e.DetalhesDoLocalId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DETALHES_DO_LOCAL_ID");

                entity.Property(e => e.DetalhesImovelId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DETALHES_IMOVEL_ID");

                entity.Property(e => e.StatusVenda)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("STATUS_VENDA");

                entity.Property(e => e.TermosDeUso)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("TERMOS_DE_USO");

                entity.Property(e => e.ValorVenda)
                    .HasPrecision(10)
                    .HasColumnName("VALOR_VENDA");

                entity.HasOne(d => d.AnuncioImovel)
                    .WithMany(p => p.DetalhesVenda)
                    .HasForeignKey(d => d.AnuncioImovelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DETALHES_VENDA_ANUNCIO_IMOVEL1");

                entity.HasOne(d => d.DetalhesDoLocal)
                    .WithMany(p => p.DetalhesVenda)
                    .HasForeignKey(d => d.DetalhesDoLocalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DETALHES_VENDA_DETALHES_DO_LOCAL1");

                entity.HasOne(d => d.DetalhesImovel)
                    .WithMany(p => p.DetalhesVenda)
                    .HasForeignKey(d => d.DetalhesImovelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DETALHES_VENDA_DETALHES_IMOVEL1");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("CEP");

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("COMPLEMENTO");

                entity.Property(e => e.Iptu)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("IPTU");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("NUMERO");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Celuar)
                    .HasMaxLength(45)
                    .HasColumnName("CELUAR");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("NOME");

                entity.Property(e => e.Senha)
                    .HasColumnType("int(11)")
                    .HasColumnName("SENHA");
            });

            modelBuilder.Entity<UsuarioRole>(entity =>
            {
                entity.ToTable("usuario_role");

                entity.HasIndex(e => e.UsuarioId, "fk_USUARIO_ROLE_USUARIO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("NOME");

                entity.Property(e => e.UsuarioId)
                    .HasColumnType("int(11)")
                    .HasColumnName("USUARIO_ID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioRoles)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_USUARIO_ROLE_USUARIO1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
