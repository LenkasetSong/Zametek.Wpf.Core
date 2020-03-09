﻿using System;
using System.ComponentModel;
using System.Windows;

namespace Zametek.Wpf.Core.TestApp
{
    public partial class ShellView
    {
        #region Fields

        private readonly LeftAnchorableView m_LeftAnchorableView;
        private readonly BottomAnchorableView m_BottomAnchorableView;
        private readonly RightAnchorableView m_RightAnchorableView;

        #endregion

        #region Ctors

        public ShellView(
            LeftAnchorableView leftAnchorableView,
            BottomAnchorableView bottomAnchorableView,
            RightAnchorableView rightAnchorableView,
            ShellViewModel viewModel)
        {
            m_LeftAnchorableView = leftAnchorableView ?? throw new ArgumentNullException(nameof(leftAnchorableView));
            m_BottomAnchorableView = bottomAnchorableView ?? throw new ArgumentNullException(nameof(bottomAnchorableView));
            m_RightAnchorableView = rightAnchorableView ?? throw new ArgumentNullException(nameof(rightAnchorableView));
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            InitializeComponent();
        }

        #endregion

        #region Properties

        public ShellViewModel ViewModel
        {
            get
            {
                return DataContext as ShellViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        #endregion

        #region ShowLeftAnchorable

        private void ShowLeftAnchorableButtonView_Click(object sender, RoutedEventArgs e)
        {
            ShowLeftAnchorableView();
        }

        private void ShowLeftAnchorableView()
        {
            DockManager.ShowAnchorable(m_LeftAnchorableView);
        }

        private void ShowLeftAnchorableButtonViewModel_Click(object sender, RoutedEventArgs e)
        {
            ShowLeftAnchorableViewModel();
        }

        private void ShowLeftAnchorableViewModel()
        {
            DockManager.ShowAnchorable(m_LeftAnchorableView.ViewModel);
        }

        #endregion

        #region ShowBottomAnchorable

        private void ShowBottomAnchorableButtonView_Click(object sender, RoutedEventArgs e)
        {
            ShowBottomAnchorableView();
        }

        private void ShowBottomAnchorableView()
        {
            DockManager.ShowAnchorable(m_BottomAnchorableView);
        }

        private void ShowBottomAnchorableButtonViewModel_Click(object sender, RoutedEventArgs e)
        {
            ShowBottomAnchorableViewModel();
        }

        private void ShowBottomAnchorableViewModel()
        {
            DockManager.ShowAnchorable(m_BottomAnchorableView.ViewModel);
        }

        #endregion

        #region ShowRightAnchorable

        private void ShowRightAnchorableButtonView_Click(object sender, RoutedEventArgs e)
        {
            ShowRightAnchorableView();
        }

        private void ShowRightAnchorableView()
        {
            DockManager.ShowAnchorable(m_RightAnchorableView);
        }

        private void ShowRightAnchorableButtonViewModel_Click(object sender, RoutedEventArgs e)
        {
            ShowRightAnchorableViewModel();
        }

        private void ShowRightAnchorableViewModel()
        {
            DockManager.ShowAnchorable(m_RightAnchorableView.ViewModel);
        }

        #endregion

        #region CloseAllDocuments

        private void CloseAllDocuments_Click(object sender, RoutedEventArgs e)
        {
            DockManager.CloseAllDocuments();
        }

        #endregion

        #region Overrides

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            bool allClosed = DockManager.CloseAllDocuments();

            // Perhaps one of the documents isn't ready to close yet.
            e.Cancel = !allClosed;
        }

        #endregion
    }
}
