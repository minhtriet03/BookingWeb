﻿namespace BookingWeb.Server.Interfaces;

public interface IGeneric<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}