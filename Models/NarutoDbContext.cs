using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppNarutoDB.Models;

public partial class NarutoDbContext : DbContext
{
    //public NarutoDbContext()
    //{
    //}

    public NarutoDbContext(DbContextOptions<NarutoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharacterClan> CharacterClans { get; set; }

    public virtual DbSet<CharacterJutsu> CharacterJutsus { get; set; }

    public virtual DbSet<CharacterTeam> CharacterTeams { get; set; }

    public virtual DbSet<CharacterVoiceactor> CharacterVoiceactors { get; set; }

    public virtual DbSet<Clan> Clans { get; set; }

    public virtual DbSet<Jutsu> Jutsus { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Voiceactor> Voiceactors { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySql("server=localhost;database=NarutoDB;uid=root;pwd=@dm1n@dm1n", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("characters");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CharName)
                .HasMaxLength(200)
                .HasColumnName("char_name");
            entity.Property(e => e.Debut)
                .HasColumnType("json")
                .HasColumnName("debut");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(200)
                .HasColumnName("image_url");
            entity.Property(e => e.PersonalDetail)
                .HasColumnType("json")
                .HasColumnName("personal_detail");
        });

        modelBuilder.Entity<CharacterClan>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("character_clan");

            entity.HasIndex(e => e.IdCharacter, "id_character");

            entity.HasIndex(e => e.IdClan, "id_clan");

            entity.Property(e => e.IdCharacter).HasColumnName("id_character");
            entity.Property(e => e.IdClan).HasColumnName("id_clan");

            entity.HasOne(d => d.IdCharacterNavigation).WithMany()
                .HasForeignKey(d => d.IdCharacter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_clan_ibfk_1");

            entity.HasOne(d => d.IdClanNavigation).WithMany()
                .HasForeignKey(d => d.IdClan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_clan_ibfk_2");
        });

        modelBuilder.Entity<CharacterJutsu>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("character_jutsu");

            entity.HasIndex(e => e.IdCharacter, "id_character");

            entity.HasIndex(e => e.IdJutsu, "id_jutsu");

            entity.Property(e => e.IdCharacter).HasColumnName("id_character");
            entity.Property(e => e.IdJutsu).HasColumnName("id_jutsu");

            entity.HasOne(d => d.IdCharacterNavigation).WithMany()
                .HasForeignKey(d => d.IdCharacter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_jutsu_ibfk_1");

            entity.HasOne(d => d.IdJutsuNavigation).WithMany()
                .HasForeignKey(d => d.IdJutsu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_jutsu_ibfk_2");
        });

        modelBuilder.Entity<CharacterTeam>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("character_team");

            entity.HasIndex(e => e.IdCharacter, "id_character");

            entity.HasIndex(e => e.IdTeam, "id_team");

            entity.Property(e => e.IdCharacter).HasColumnName("id_character");
            entity.Property(e => e.IdTeam).HasColumnName("id_team");

            entity.HasOne(d => d.IdCharacterNavigation).WithMany()
                .HasForeignKey(d => d.IdCharacter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_team_ibfk_1");

            entity.HasOne(d => d.IdTeamNavigation).WithMany()
                .HasForeignKey(d => d.IdTeam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_team_ibfk_2");
        });

        modelBuilder.Entity<CharacterVoiceactor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("character_voiceactor");

            entity.HasIndex(e => e.IdActor, "id_actor");

            entity.HasIndex(e => e.IdCharacter, "id_character");

            entity.Property(e => e.IdActor).HasColumnName("id_actor");
            entity.Property(e => e.IdCharacter).HasColumnName("id_character");

            entity.HasOne(d => d.IdActorNavigation).WithMany()
                .HasForeignKey(d => d.IdActor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_voiceactor_ibfk_2");

            entity.HasOne(d => d.IdCharacterNavigation).WithMany()
                .HasForeignKey(d => d.IdCharacter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("character_voiceactor_ibfk_1");
        });

        modelBuilder.Entity<Clan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClanName)
                .HasMaxLength(200)
                .HasColumnName("clan_name");
        });

        modelBuilder.Entity<Jutsu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("jutsu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JutsuName)
                .HasMaxLength(200)
                .HasColumnName("jutsu_name");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("team");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TeamName)
                .HasMaxLength(200)
                .HasColumnName("team_name");
        });

        modelBuilder.Entity<Voiceactor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("voiceactor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActorName)
                .HasMaxLength(200)
                .HasColumnName("actor_name");
            entity.Property(e => e.LanguageVersion)
                .HasMaxLength(20)
                .HasColumnName("language_version");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
