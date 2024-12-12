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

//update user
export const updateUser = async (userVm) => {
    try {
        const response = await axiosInstance.put('/api/User', userVm)
        console.log(userVm)
        return response.data;
    }
    catch (error) {
        throw error.response?.data || error.message || "An unexpected error occurred.";
    }
};

export const changePass = async (data) => {
    try {
        const response = await axiosInstance.post('/api/Account/changePass',data);
        return response.data;
    }
    catch (error) {
        throw error.response?.data || error.message || "An unexpected error occurred.";
    }
};

//get vé xe
export const getVeXeUser = async (id) => {
    try {
        const response = await axiosInstance.get(`/api/vexe/user=${id}`);
        return response.data;
    } catch (error) {
        console.error('Error fetching tickets:', error.response?.data || error.message);
        throw error;
    }
};

export const createPhieuDat = async (data) => {
    try {
        const response = await axiosInstance.post('/api/order', data);
        return response.data;
    } catch (error) {
        throw error.response?.data || error.message || "An unexpected error occurred.";
    }
}
