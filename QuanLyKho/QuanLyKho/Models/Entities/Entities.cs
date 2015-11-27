namespace QuanLyKho.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }

        public virtual DbSet<BC_CuoiNgay> BC_CuoiNgay { get; set; }
        public virtual DbSet<ChuCuaHang> ChuCuaHangs { get; set; }
        public virtual DbSet<CongNo> CongNoes { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<CT_HoaDon> CT_HoaDon { get; set; }
        public virtual DbSet<CuaHang> CuaHangs { get; set; }
        public virtual DbSet<DoiTac> DoiTacs { get; set; }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<HinhAnh> HinhAnhs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhoHang> KhoHangs { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<MOD> MODs { get; set; }
        public virtual DbSet<NganQuy> NganQuys { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhomHang> NhomHangs { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<PhieuThuChi> PhieuThuChis { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BC_CuoiNgay>()
                .Property(e => e.TongThu)
                .HasPrecision(15, 3);

            modelBuilder.Entity<BC_CuoiNgay>()
                .Property(e => e.TongChi)
                .HasPrecision(15, 3);

            modelBuilder.Entity<ChuCuaHang>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.ChuCuaHang)
                .HasForeignKey(e => e.TenTK_Chu);

            modelBuilder.Entity<CongNo>()
                .Property(e => e.GiaTri)
                .HasPrecision(15, 3);

            modelBuilder.Entity<CuaHang>()
                .HasMany(e => e.ChuCuaHangs)
                .WithRequired(e => e.CuaHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DoiTac>()
                .HasMany(e => e.CongNoes)
                .WithRequired(e => e.DoiTac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DoiTac>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.DoiTac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DoiTac>()
                .HasMany(e => e.NganQuys)
                .WithRequired(e => e.DoiTac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DoiTac>()
                .HasMany(e => e.PhieuThuChis)
                .WithRequired(e => e.DoiTac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DoiTac>()
                .HasMany(e => e.NhomHangs)
                .WithMany(e => e.DoiTacs)
                .Map(m => m.ToTable("CT_NhomHang").MapLeftKey("MaDT").MapRightKey("MaNH"));

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.CT_HoaDon)
                .WithRequired(e => e.HangHoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.HinhAnhs)
                .WithRequired(e => e.HangHoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CongNoes)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CT_HoaDon)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.PhieuThuChis)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoHang>()
                .HasMany(e => e.CuaHangs)
                .WithRequired(e => e.KhoHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiHang>()
                .HasMany(e => e.HangHoas)
                .WithRequired(e => e.LoaiHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiHang>()
                .HasMany(e => e.KhoHangs)
                .WithRequired(e => e.LoaiHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiHang>()
                .HasMany(e => e.NhomHangs)
                .WithRequired(e => e.LoaiHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NganQuy>()
                .Property(e => e.SoTien)
                .HasPrecision(15, 3);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.NhanVien)
                .HasForeignKey(e => e.TenTK_NV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomHang>()
                .HasMany(e => e.HangHoas)
                .WithRequired(e => e.NhomHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhanQuyen>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.PhanQuyen)
                .WillCascadeOnDelete(false);
        }
    }
}
