import axios from 'axios';
import { logout } from "@/redux/actions/authAction"; 
import { isTokenExpired } from "@/utils/jwtHelper";


const axiosInstance = axios.create({
    baseURL: "http://localhost:5108",
    withCredentials: true,
});

const publicURLs = ["/login", "/register"];

const setupInterceptors = (store) => {
    axiosInstance.interceptors.request.use(
        async (config) => {
            try {
                if (publicURLs.some((url) => config.url.includes(url))) {
                    return config;
                }

                const token = document.cookie
                    .split("; ")
                    .find((row) => row.startsWith("jwt="))
                    ?.split("=")[1];

                    if (!token) {
                        // Kiểm tra nếu URL là API yêu cầu xác thực
                        const protectedURLs = ["/api/Account"];
                        if (protectedURLs.some((url) => config.url.includes(url))) {
                            console.warn("Yêu cầu tới API yêu cầu xác thực nhưng không có token!");
                            throw new axios.Cancel("No token, access denied.");
                        }
        
                        // Nếu không phải API yêu cầu xác thực, cho phép tiếp tục
                        return config;
                    }
        
                    // Trường hợp token không hợp lệ hoặc hết hạn
                    if (isTokenExpired(token)) {
                        console.warn("Token hết hạn.");
                        await store.dispatch(logout());
                        window.location.href = "/login";
                        throw new axios.Cancel("Token expired, redirecting to login.");
                    }
        

                config.headers.Authorization = `Bearer ${token}`;
                return config;
            } catch (error) {
                console.error("Interceptor Error:", error);
                return Promise.reject(error);
            }
        },
        (error) => {
            console.error("Request Error:", error);
            return Promise.reject(error);
        }
    );
};



export { axiosInstance, setupInterceptors };


