import { axiosInstance } from '@/utils/axiosInstance';

// Đăng ký user
export const registerUser = async (userData) => {
  try {
    const response = await axiosInstance.post('/api/Account/register', userData);
    return response.data;
  } catch (error) {
    throw error.response?.data || error.message || "An unexpected error occurred.";
  }
};
