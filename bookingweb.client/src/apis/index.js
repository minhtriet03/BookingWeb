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

export const createOrder = async (orderData) => {
    try {
        const response = await axiosInstance.post('/api/Order', orderData);
        return response.data;
    } catch (error) {
        throw error.response?.data || error.message || "An unexpected error occurred.";
    }
    }