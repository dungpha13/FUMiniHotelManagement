﻿using DataAccessObjects.DTO;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Dungphase172122WPF
{
    /// <summary>
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class CustomerManagement : UserControl
    {
        private readonly ICustomerService _service;

        public CustomerManagement()
        {
            InitializeComponent();
            _service = ((App)Application.Current).ServiceProvider.GetRequiredService<ICustomerService>() ?? throw new ArgumentNullException(nameof(CustomerService));
            Loaded += LoadData;
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            dgCustomers.ItemsSource = null;
            var customers = _service.GetCustomers(c => c.CustomerFullName.ToUpper().Contains(txtSearch.Text.ToUpper()));
            dgCustomers.ItemsSource = customers;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                try
                {
                    var customers = _service.GetCustomers(c => c.CustomerFullName.ToUpper().Contains(txtSearch.Text.ToUpper()));
                    dgCustomers.ItemsSource = null;
                    dgCustomers.ItemsSource = customers;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                LoadData(sender, e);
            }
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addEditCustomerDialog = new AddEditCustomerDialog();
            if (addEditCustomerDialog.ShowDialog() == true)
            {
                var newCustomer = addEditCustomerDialog.Customer;
                await _service.AddCustomer(newCustomer);
                LoadData(sender, e);
            }
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is CustomerDTO selectedCustomer)
            {
                var addEditCustomerDialog = new AddEditCustomerDialog(selectedCustomer);
                if (addEditCustomerDialog.ShowDialog() == true)
                {
                    var updatedCustomer = addEditCustomerDialog.Customer;
                    await _service.UpdateCustomer(updatedCustomer);
                    LoadData(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "Edit Customer", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is CustomerDTO selectedCustomer)
            {
                if (MessageBox.Show($"Are you sure you want to delete Customer {selectedCustomer.CustomerFullName}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    await _service.DeleteCustomer(selectedCustomer.CustomerId);
                    LoadData(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Delete Customer", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
