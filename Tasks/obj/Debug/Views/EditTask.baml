   M S B A M L   `   `   `  ����@  <Tasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Tasks.ViewsTasks.Views  5   	   3clr-namespace:Tasks.ViewModelsTasks.ViewModels  61       Tasks.Views.EditTask   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Tasks.Views     5   	   5
ViewModelsclr-namespace:Tasks.ViewModels     61     � Title$  EditTask��5   	   $	��450��6   $	��800��6'    � DataContext 5
      !   Tasks.ViewModels.TreeViewVM  5   
   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��Name: ��6   $��0��6"   $��24(�6/   $��Center=�6=   $��Center=�6Z   �� 5   
   -   5         ��Name$ nameTextBox��5      $��0��6'   $��1��64   �� 5    
   $��Description: ��6   $��1��6)   $��24(�66   $��Center=�6D   $��Center=�6a   �� 5!   
   -   5        $ descriptionTextBox��5!      $��1��6.   $��1��6;   �� 5"   
   $��7��6   $��Status��6!   $��24(�6/   $��Center=�6=   $��Center=�6Z   �� 5#   
   -   5         ��Name$ statusCheckBox��5#       d� 	IsChecked$ FalseY�6+   $��7��6=   $��1��6J   $��Center=�6Z   $��Center=�6w   �� 5$   
   $��2��6   $
��Type��6!   $��24(�6-   $��Center=�6;   $��Center=�6X   �� 5%   
   -   5         ��Name$ typeComboBox��5%      $��2��6)   $��1��66   .@�5&      �� $��Minor��6   $��24(�6+   $��Center=�69   $��Center=�6V   �� 5'      $��Major��6   $��24(�6+   $��Center=�69   $��Center=�6V   5(      �� 5)   
   $��Category��6   $��3��6$   $��24(�61   $��Center=�6?   $��Center=�6\   �� 5*   
   -   5        $ categoryComboBox��5*      $��3��6-   $��1��6:    �� DisplayMemberPath$
 Name��6m   	 �� SelectedValuePath$
	 Name��5+      ��5*   J   �� *
Categories+5,      �� 5-   
   $��Priority��6   $��4��6$   $��24(�61   $��Center=�6?   $��Center=�6\   �� 5.   
   -   5        $ priorityComboBox��5.      $��4��6-   $��1��6:   .@�5/      �� $	��Low��6   $��24(�6)   $��Center=�67   $��Center=�6T   �� 50      $��Medium��6   $��24(�6,   $��Center=�6:   $��Center=�6W   �� 51      $
��High��6   $��24(�6*   $��Center=�68   $��Center=�6U   52      �� 53   
   $��Deadline��6   $��5��6$   $��24(�61   $��Center=�6?   $��Center=�6\   (  "System.Windows.Controls.DatePicker  54   
   -   5        
  Name$
 deadlineDatePicker��54      $��5��61   $��1��6>   $��Center=�6N   $��Center=�6k   �� 55   
   $��Date of finish��6   $��6��6*   $��24(�67   $��Center=�6E   $��Center=�6b     56   
   -   5        $
 dateOfFinishDatePicker��56      $��6��65   $��1��6B   $��Center=�6R   $��Center=�6o   �� 57   
   -	   5        $��8��57      $��2��6   $��
ExtraBlack"�62   $��24(�6J   .��6k   EDIT6q   58      59      