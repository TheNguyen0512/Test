﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using TFU.Models.IdentityModels;

namespace TFU.DAL.Interfaces
{
	public interface IIdentityRepository
	{
		Task<UserDTO> GetByEmailAsync(string email);
		Task<long> AddUserAsync(UserDTO dto, string password);
		Task<bool> UpdateAsync(UserDTO dto);
		Task<UserDTO> GetByIdAsync(long id);
		Task<UserDTO> GetByExternalIdAsync(string id);
		Task<bool> CheckPasswordAsync(UserDTO dto, string password);
		Task<bool> HasPasswordAsync(UserDTO dto);
		Task<IdentityResult> AddPasswordAsync(UserDTO dto, string password);
		/// <summary>
		/// lấy thông tin user theo điện thoại
		/// </summary>
		/// <param name="phoneNumber">số điện thoại</param>
		/// <returns></returns>
		Task<UserDTO> GetByPhoneAsync(string phoneNumber);
		/// <summary>
		/// xác thực email
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="code"></param>
		/// <returns></returns>
		Task<bool> ConfirmEmailAsync(string userId, string code);
		/// <summary>
		/// thay đổi mật khẩu
		/// </summary>
		/// <param name="userId">id user cần thay đổi mật khẩu</param>
		/// <param name="passwordNew">mật khẩu mới</param>
		/// <returns></returns>
		Task<bool> ChangePassword(string userId, string passwordNew);
		/// <summary>
		/// thêm role cho người dùng theo tên role
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="roleName"></param>
		/// <returns></returns>
		Task<bool> AddRoleByNameAsync(string userId, string roleName);
		/// <summary>
		/// generate email confirm token
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		Task<string> GenerateEmailConfirmationTokenAsync(UserDTO user);
		Task<string> GeneratePasswordResetTokenAsync(UserDTO user);
		Task<bool> ResetPasswordAsync(string userId, string token, string newPassword);
		/// <summary>
		/// Is user in role
		/// </summary>
		/// <param name="user"></param>
		/// <param name="role"></param>
		/// <returns></returns>
		Task<bool> IsUserInRole(UserDTO user, string role);
		/// <summary>
		/// xóa quyền của user
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		Task<bool> DeleteRoleByUser(long userId);

		/// <summary>
		/// DeleteListRole
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		Task<bool> DeleteListRole(long[] ids);
		/// <summary>
		/// Get list roles by userId
		/// </summary>
		/// <param name="userId">The user identified.</param>
		/// <returns></returns>
		Task<string[]> GetRolesAsync(long userId);
		/// <summary>
		/// Verified user can be access to the function.
		/// </summary>
		Task<bool> VerifyPermission(long userId, string claim);

		/// <summary>
		/// lấy toàn bộ role quản trị
		/// </summary>
		/// <returns></returns>
		Task<List<RoleDTO>> GetRolesAdmin();
		Task<string> GenerateJwtToken(UserDTO user, bool isRemember, bool isAdmin, bool isCreator = false, bool isArtist = false);
	}
}
