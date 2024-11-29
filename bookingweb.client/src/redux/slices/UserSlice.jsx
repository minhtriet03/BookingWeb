import { createSlice } from "@reduxjs/toolkit";
import { SetUser } from "../actions/UserAction";

const UserSlice = createSlice({
    name: "user",
    initialState: {
        userInfo: null,
    },
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(SetUser.fulfilled, (state, action) => {
                state.userInfo = action.payload || null;
            })
            .addCase(SetUser.rejected, (state) => {
                state.userInfo = null;
            });
    },
});

export default UserSlice.reducer;

