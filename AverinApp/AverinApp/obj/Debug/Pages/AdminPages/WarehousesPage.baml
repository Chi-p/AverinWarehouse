   M S B A M L   `   `   `  ����D  @AverinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AverinApp.Pages.AdminPagesAverinApp.Pages.AdminPages  5      /    )AverinApp.Pages.AdminPages.WarehousesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:AverinApp.Pages.AdminPages     5        N� Title$.  (Администратор. Склады��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6K   .+�5      ��    TbkBody#��[  6    �� TextAlignment$ Right=�69   $%��Название
/  Адрес:��6O   �� 5      -   5        $��	TbxSearch��5      $	��150��6'   �� 5      #��[  6   $��Вместимость:��69   �� 5      -   5        $��TbxCapacity��5      $��65��6)    �� TextAlignment$ Center=�64    �� 	MaxLength$ 6��6K   6Y   �� 5      #��[  6   $	��т.��69   $��0 5 20 5q�6C   �� 5      #��[  6   $��Оператор:��69   �� 5      -   5        $��CbxOperator��5      $	��200��6*    �� DisplayMemberPath$ FullName��66   �� 5      -   5        $��	BtnSearch��5   0   $��Center=�6   $��
Поиск��6A   $
��auto��6Q   $
��15 5q�6^   $��15 5 5 5q�6m   6   �� 5      -   5        $��BtnClear��5   0   $��Center=�6   $��Очистить��6@   $
��auto��6S   $
��15 5q�6`   $��5 5 5 5q�6o     	BtnCancel#��[ 6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��DGWarehouses��5       $��1��6   $��
15 0 15 10q�64      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 0.60* 67   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6E   �� *Name+  5!      $ 
Адрес��6%   $	 1.75* 64   
 6B   �� *	Address+  5"      $ Вместимость��6%   $	 0.70* 6:   
 6H   �� *
Capacity+ �� StringFormat$ 
{0:N2} т.��  5#      $ Оператор��6%   $	 1.40* 67   
 6E   �� *OperatorName+4  .System.Windows.Controls.DataGridTemplateColumn  5$         CellTemplate 5%      �� 5&      .R�5'      �� $��BtnEdit��6%   -   5        $ ��Редактировать��5'   J   $
��10 3q�6b   $
��auto��6q   5(      5*        5+       5,      �� 5-      .R�5.      �� $��	BtnDelete��6%   -   5        $��Удалить��5.   N   $
��auto��6`   $
��10 3q�5/   %   #��[ 64   50      52      54      �� 56   
   -	   5        $��BtnAdd��57   0   $��2��56      $��Right=�6   $��0 0 15 5q�6:   $
��auto��6L   $
��20 5q�6Y   $,��&Добавить новый склад��57      $��Center=�6>   6Y   59      5:      