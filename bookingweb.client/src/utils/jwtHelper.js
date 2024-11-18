import { jwtDecode } from "jwt-decode";

const getUserFromToken = () => {
  const token = document.cookie
      .split("; ")
      .find((row) => row.startsWith("jwt_token="))
      ?.split("=")[1];
  if (!token) return null;

  try {
      return jwtDecode(token);
  } catch {
      console.error("Token không hợp lệ");
      return null;
  }
};

const isTokenExpired = (token) => {
    if (!token) return true; 
    try {
        const decoded = jwtDecode(token);
        return decoded.exp * 1000 < Date.now(); 
    } catch (error) {
        console.error("Invalid token format:", error);
        return true;
    }
};


export { getUserFromToken, isTokenExpired };