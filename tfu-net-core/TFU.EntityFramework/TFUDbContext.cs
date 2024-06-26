﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TFU.Models.IdentityModels;

namespace TFU.EntityFramework
{
	public class TFUDbContext : IdentityDbContext<UserDTO, RoleDTO, long, UserClaimDTO, UserRoleDTO, UserLoginDTO, RoleClaimDTO, UserTokenDTO>
	{
		public TFUDbContext(DbContextOptions<TFUDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserDTO>(b =>
			{
				b.ToTable("TFU_Users");
				// Each User can have many UserClaims
				b.HasMany(e => e.Claims)
					 .WithOne(e => e.User)
					 .HasForeignKey(uc => uc.UserId)
					 .IsRequired();

				// Each User can have many UserLogins
				b.HasMany(e => e.Logins)
					 .WithOne(e => e.User)
					 .HasForeignKey(ul => ul.UserId)
					 .IsRequired();

				// Each User can have many UserTokens
				b.HasMany(e => e.Tokens)
					 .WithOne(e => e.User)
					 .HasForeignKey(ut => ut.UserId)
					 .IsRequired();

				// Each User can have many entries in the UserRole join table
				b.HasMany(e => e.UserRoles)
					 .WithOne(e => e.User)
					 .HasForeignKey(ur => ur.UserId)
					 .IsRequired();
			});

			modelBuilder.Entity<UserClaimDTO>(b =>
			{
				b.ToTable("TFU_UserClaims");
			});

			modelBuilder.Entity<UserLoginDTO>(b =>
			{
				b.ToTable("TFU_UserLogins");
			});

			modelBuilder.Entity<UserTokenDTO>(b =>
			{
				b.ToTable("TFU_UserTokens");
			});

			modelBuilder.Entity<RoleDTO>(b =>
			{
				b.ToTable("TFU_Roles");
				// Each Role can have many entries in the UserRole join table
				b.HasMany(e => e.UserRoles)
					 .WithOne(e => e.Role)
					 .HasForeignKey(ur => ur.RoleId)
					 .IsRequired();

				// Each Role can have many associated RoleClaims
				b.HasMany(e => e.RoleClaims)
					 .WithOne(e => e.Role)
					 .HasForeignKey(rc => rc.RoleId)
					 .IsRequired();
			});

			modelBuilder.Entity<RoleClaimDTO>(b =>
			{
				b.ToTable("TFU_RoleClaims");
			});

			modelBuilder.Entity<UserRoleDTO>(b =>
			{
				b.ToTable("TFU_UserRoles");
			});
		}
	}
}
