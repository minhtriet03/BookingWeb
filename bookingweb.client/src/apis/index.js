import { axiosInstance } from '@/utils/axiosInstance';

// Đăng ký user
export const registerUser = async (userData) => {
  try {
    const response = await axiosInstance.post('/api/Account/register', userData);
    return response.data;
  } catch (error) {
    throw error.response?.data || error.message || "An unexpected error occurred.";
<<<<<<< HEAD
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
=======
  }
};
>>>>>>> 35d812ffe9eedbf4753bd9855622388b6880697a
