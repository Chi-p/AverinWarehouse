   M S B A M L   `   `   `  ����D  @AverinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AverinApp.WindowsAverinApp.Windows  5   	   "    AverinApp.Windows.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:AverinApp.Windows     5   	   -   5        $	��600��5	   	   $	��600��6   $
��1000��6&   $
��1000��66     � WindowStartupLocation$  CenterScreen=�6Z    � Title 5   	   ��  �� ElementName$ 	MainFrame�� �� Path$ Content.Title�.��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   � -   5        $��	MainTitle��5      $��0��6       PColor_First#��[  6-   .+�5      �� -   5        $��BtnBack��5      $
��auto��6$   $
��20 5q�61   $��18(�6@   $
��Left=�6N   $��Center=�6i   $��
Назад��5      $
��15 5q�6%   $y�	Collapsed=�63   6J   �� 5      $��Center=�6   $��Center=�64   .+�5      �� $K��E/AverinApp;component/Resources/Pictures/pyaterochka_redbackground.png��6   $��5 5 5 0q�6g   $��50��6x   �� 5      $3��-Распределительный центр��6     TbkBody#��[ 6;    �� TextAlignment$ Center=�6\   
�������$��15 0 5 5q�6�   $��26(�6�   5      �� 5      -   5        $��	BtnLogout��5      $
��auto��6&   $
��20 5q�63   $��18(�6B   $��Right=�6P   $��Center=�6l   $��
Выйти��5      $
��15 5q�6%   $y�	Collapsed=�63   6J   5       � 5   
   -   5        $��	MainFrame��5      $��1��6!     � NavigationUIVisibility$ Hidden=�6.   6N   � 5   
   $��2��6     SColor_DarkThird#��[ 6   .+�5       �� -   5        $��TbkTime��5       $a��[Время работы в приложении: 0 часов, 0 минут, 0 секунд��6'   $��Center=�6d   
�������$��20(�5!   +   $��Center=�69   #��[ 6V   5"      5$      5&      