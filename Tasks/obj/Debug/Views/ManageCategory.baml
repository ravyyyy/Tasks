   M S B A M L   `   `   `  ����@  <Tasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Tasks.ViewsTasks.Views  5   	   3clr-namespace:Tasks.ViewModelsTasks.ViewModels  61        Tasks.Views.ManageCategory   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Tasks.Views     5   	   5
ViewModelsclr-namespace:Tasks.ViewModels     61     � Title$  ManageCategory��5   	   $	��450��6    $	��800��6-    � DataContext 5
      !   Tasks.ViewModels.TreeViewVM  5   
   .��5      � $��0,0,0,-6q�6   .+�5   
   �� $��Category name: ��6   $��10,93,667,293q�6+   �� 5   
   -   5         ��Name$ categoryTextBox��5      $��138,93,412,308q�6+   �� 5   
   -   5         ��Name$ categoryComboBox��5      $��532,10,47,338q�6-    �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$
 Name��5      ��5      �� *
Categories+5      �� 5   
   -   5        $��116,325,529,66q�5      .��6;   ADD6@   �� 5   
   -   5        $��310,325,335,66q�5      .��6>   DELETE6F   �� 5   
   -   5        $��499,325,146,66q�5      $
��EDIT��6)   68   5      5      