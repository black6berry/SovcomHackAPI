using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SovcomHackAPI.Models;

public partial class SovcomHackContext : DbContext
{
    private string _connectionString = "";

    public SovcomHackContext()
    {
    }

    public SovcomHackContext(DbContextOptions<SovcomHackContext> options, string _connectionString)
        : base(options)
    {
        var builder = new ConfigurationBuilder();
        // установка пути к текущему каталогу
        builder.SetBasePath(Directory.GetCurrentDirectory());
        // получаем конфигурацию из файла appsettings.json
        builder.AddJsonFile("appsettings.json");
        // создаем конфигурацию
        var config = builder.Build();
        // получаем строку подключения
        this._connectionString = config.GetConnectionString("dbConnection");

    }

    public virtual DbSet<Accident> Accidents { get; set; }

    public virtual DbSet<ActiveBag> ActiveBags { get; set; }

    public virtual DbSet<BankAccAvailable> BankAccAvailables { get; set; }

    public virtual DbSet<BankAccountClient> BankAccountClients { get; set; }

    public virtual DbSet<CategoryAccident> CategoryAccidents { get; set; }

    public virtual DbSet<CheckMoneyDatum> CheckMoneyData { get; set; }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    public virtual DbSet<LogHistoryOperation> LogHistoryOperations { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SessionUserBidding> SessionUserBiddings { get; set; }

    public virtual DbSet<TypeCard> TypeCards { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<ViewProductUserOnCard> ViewProductUserOnCards { get; set; }

    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accident>(entity =>
        {
            entity.ToTable("Accident");

            entity.Property(e => e.Id).HasComment("ИД");
            entity.Property(e => e.CategoryId).HasComment("ИД Категория травмоопасности");
            entity.Property(e => e.DateAccident)
                .HasComment("Дата происшествия")
                .HasColumnType("datetime");
            entity.Property(e => e.GeoposionX)
                .HasComment("Координата по Ox")
                .HasColumnType("decimal(5, 5)");
            entity.Property(e => e.GeoposionY)
                .HasComment("Координата по OY")
                .HasColumnType("decimal(5, 5)");
            entity.Property(e => e.SessionId).HasComment("ИД сессии, когда произошло происшествие");
            entity.Property(e => e.UserId).HasComment("ИД Пользователя");
            entity.Property(e => e.ValueGet)
                .HasComment("Получаемое значение")
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Accidents)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accident_CategoryAccident");

            entity.HasOne(d => d.Session).WithMany(p => p.Accidents)
                .HasForeignKey(d => d.SessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accident_SessionUser");

            entity.HasOne(d => d.User).WithMany(p => p.Accidents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accident_User");
        });

        modelBuilder.Entity<ActiveBag>(entity =>
        {
            entity.ToTable("ActiveBag");

            entity.Property(e => e.LastDateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.ActiveBags)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ActiveBag_User");
        });

        modelBuilder.Entity<BankAccAvailable>(entity =>
        {
            entity.HasKey(e => new { e.BankAccountId, e.CreditCardId });

            entity.ToTable("BankAccAvailable");

            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.BankAccount).WithMany(p => p.BankAccAvailables)
                .HasForeignKey(d => d.BankAccountId)
                .HasConstraintName("FK_BankAccAvailable_BankAccountClient");

            entity.HasOne(d => d.CreditCard).WithMany(p => p.BankAccAvailables)
                .HasForeignKey(d => d.CreditCardId)
                .HasConstraintName("FK_BankAccAvailable_CreditCard");
        });

        modelBuilder.Entity<BankAccountClient>(entity =>
        {
            entity.ToTable("BankAccountClient");

            entity.Property(e => e.Id).HasComment("ИД");
            entity.Property(e => e.Number).HasMaxLength(35);
            entity.Property(e => e.UserId).HasComment("ИД Клиента");
            entity.Property(e => e.ValueMoney).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CheckMoneyData).WithMany(p => p.BankAccountClients)
                .HasForeignKey(d => d.CheckMoneyDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BankAccountClient_CheckMoneyData");

            entity.HasOne(d => d.User).WithMany(p => p.BankAccountClients)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ConnectedUserServices_User");
        });

        modelBuilder.Entity<CategoryAccident>(entity =>
        {
            entity.ToTable("CategoryAccident");

            entity.Property(e => e.Id).HasComment("ИД");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasComment("Описание категории");
            entity.Property(e => e.Effects)
                .HasMaxLength(250)
                .HasComment("Какие угрозы жизни");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasComment("Название категории");
            entity.Property(e => e.RangeFrom)
                .HasComment("Диапазон ОТ")
                .HasColumnType("decimal(5, 5)");
            entity.Property(e => e.RangeTo)
                .HasComment("Диапазон ДО")
                .HasColumnType("decimal(5, 5)");
        });

        modelBuilder.Entity<CheckMoneyDatum>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CreditCard>(entity =>
        {
            entity.ToTable("CreditCard");

            entity.Property(e => e.Id).HasComment("ИД");
            entity.Property(e => e.Cvv)
                .HasComment("Код CVV")
                .HasColumnName("CVV");
            entity.Property(e => e.DateOfReceiving)
                .HasComment("Дата, до которой нужно карту обновить")
                .HasColumnType("datetime");
            entity.Property(e => e.Day).HasComment("День действителен ДО");
            entity.Property(e => e.Number)
                .HasMaxLength(21)
                .HasComment("Номер карты");
            entity.Property(e => e.TypeCardId).HasComment("ИД типа карты (зарплатная, кредитная)");
            entity.Property(e => e.ValueMoney)
                .HasComment("Объем денег на карте (Мы понимаем, что должен быть счет и должен быть привязана карта к нему, а деньги на счету, но чтобы сэкономить время - вы сразу деньги храним на карте)")
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Year).HasComment("Год действителен ДО");

            entity.HasOne(d => d.TypeCard).WithMany(p => p.CreditCards)
                .HasForeignKey(d => d.TypeCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreditCard_TypeCard");
        });

        modelBuilder.Entity<LogHistoryOperation>(entity =>
        {
            entity.ToTable("LogHistoryOperation");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.ValueMoney).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.BankAccountClient).WithMany(p => p.LogHistoryOperations)
                .HasForeignKey(d => d.BankAccountClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogHistoryOperation_BankAccountClient");

            entity.HasOne(d => d.Operation).WithMany(p => p.LogHistoryOperations)
                .HasForeignKey(d => d.OperationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogHistoryOperation_Operation");

            entity.HasOne(d => d.User).WithMany(p => p.LogHistoryOperations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogHistoryOperation_User");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.ToTable("Operation");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id).HasComment("ИД");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasComment("Название роли");
            entity.Property(e => e.NameFs)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("Первая буква в названии роли")
                .HasColumnName("Name_FS");
        });

        modelBuilder.Entity<SessionUserBidding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SessionUser");

            entity.ToTable("SessionUserBidding");

            entity.Property(e => e.Id).HasComment("ИД");
            entity.Property(e => e.Get).HasComment("ИД Продукта компании");
            entity.Property(e => e.TimeSpanActive).HasComment("Время начала (момент, когда тумблер true)");
            entity.Property(e => e.TimeSpanFinish).HasComment("Время конца (момент, когда тумблер false)");
            entity.Property(e => e.UserId).HasComment("ИД Пользователя");

            entity.HasOne(d => d.User).WithMany(p => p.SessionUserBiddings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SessionUser_User");
        });

        modelBuilder.Entity<TypeCard>(entity =>
        {
            entity.ToTable("TypeCard");

            entity.Property(e => e.Id).HasComment("ИД");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasComment("Тип карты");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasComment("ИД");
            entity.Property(e => e.IsActive).HasComment("Статус пользователя");
            entity.Property(e => e.LastConnect)
                .HasComment("Последнее подключение")
                .HasColumnType("datetime");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasComment("Логин пользователя");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasComment("Имя");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasComment("Пароль пользователя");
            entity.Property(e => e.Patronomic)
                .HasMaxLength(30)
                .HasComment("Отчество");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .HasComment("Телефон");
            entity.Property(e => e.RoleId).HasComment("ИД роли пользователя");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasComment("Фамилия");
            entity.Property(e => e.Verified).HasComment("Подтверждение аккаунта пользователя");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<ViewProductUserOnCard>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewProductUserOnCard");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Number).HasMaxLength(21);
            entity.Property(e => e.Patronomic).HasMaxLength(30);
            entity.Property(e => e.Surname).HasMaxLength(30);
            entity.Property(e => e.Title).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
