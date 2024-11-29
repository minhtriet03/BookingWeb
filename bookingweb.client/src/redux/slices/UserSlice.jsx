import { createSlice } from "@reduxjs/toolkit";
import { SetUser } from "../actions/UserAction";

const UserSlice = createSlice({
    name: "user",
    initialState: {
		userInfo: [],
    },
		reducers: {},
	extraReducers:(builder) => {
		builder
			.addCase(SetUser.fulfilled,(state,action) => {
				const infor = action.payload
				state.userInfo = infor?.userInfo || []
			})
			.addCase(SetUser.rejected,(state) => {
				state.userInfo = []
			})
	}
});

export default UserSlice.reducer
