   M S B A M L   `   `   `  ����@  <Tasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Tasks.ViewsTasks.Views  5   	   3clr-namespace:Tasks.ViewModelsTasks.ViewModels  61       Tasks.Views.SearchTask   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Tasks.Views     5   	   5
ViewModelsclr-namespace:Tasks.ViewModels     61     � Title$  
Find Tasks��5   	   $	��389��6   $	��495��6)    � DataContext 5
      !   Tasks.ViewModels.TreeViewVM  5   
   .��5      � .+�5   
   �� -   5         ��Name$ imageSource��5      $��9,11,349,239q�6%   6=   �� 5   
   $��150,34,192,268q�6   $��20(�6(   .��66   
Find Tasks6B   �� 5   
   $��150,73,154,236q�6   .��6(   Find tasks in all to-do lists6G   �� 5   
   $��13,142,353,186q�6   $��20(�6,   $
��Bold"�6:   
Find what:6X   �� 5   
   -   5         ��Name$ findTaskTextBox��5      $��124,142,60,186q�6+   6E   �� 5   
   -   5         ��Name$ findTaskCheckBox��5      $��10,226,429,102q�6-   6G   �� 5   
   $��34,220,269,102q�6   .��6(   Search in current view only6E   �� 5   
   -   5         ��Name$ findTaskItemsFound��5      $��10,246,305,74q�60   6I   �� 5   
   -   5         ��Name$ findTaskFindButton��5      $��280,226,123,100q�6-   .��6_   Find6e   �� 5   
   -   5        $ closeTaskFindButton��5      $��377,226,26,100q�6.   $��Close��6F   6V   �� 5   
   -   5         ��Name$ findTaskListView��5   &   $��	0,276,0,0q�6   ��6@   �� *pairs+ �� View 5      �� 5      !	 �� ColumnHeaderContainerStyle	 5      �� 5      
 �� 
TargetType"
 ��6    .�5      ��  �� Property �@J�IsHitTestVisible �� Value .  6A   5      .P�5!      �� $��Title��6%    �� DisplayMemberBinding 64   �� *Key+�� 5"      $��Location��6%    67   �� *
Value.Name+5#      5%      5&      5'      