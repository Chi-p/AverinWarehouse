   M S B A M L   `   `   `  ����D  @AverinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AverinApp.Pages.AdminPagesAverinApp.Pages.AdminPages  5      -    'AverinApp.Pages.AdminPages.ProductsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:AverinApp.Pages.AdminPages     5        N� Title$2  ,Администратор. Продукты��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6K   .+�5      ��    TbkBody#��[  6    �� TextAlignment$ Right=�69   $��Поиск:��6O   �� 5      -   5        $��	TbxSearch��5      $	��150��6'   �� 5      #��[  6   $5��/Сертификаты
в промежутке:��69   �� 5      #��[  6   $
��от��69   (  "System.Windows.Controls.DatePicker  5      -   5        $��DpStartDate��5      �� 5      #��[  6   $
��до��69     5      -   5        $��	DpEndDate��5      �� 5      -   5        $��	BtnSearch��5   0   $��Center=�6   $��
Поиск��6A   $
��auto��6Q   $
��15 5q�6^   $��15 5 5 5q�6m   6   �� 5      -   5        $��BtnClear��5   0   $��Center=�6   $��Очистить��6@   $
��auto��6S   $
��15 5q�6`   $��5 5 5 5q�6o     	BtnCancel#��[ 6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��
DGProducts��5       $��1��6   $��
15 0 15 10q�62      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Number+  5!      $ Название��6%   $ 1* 67    6B   �� *Name+  5"      $ Вес��6%   $
 0.5* 62    6?   �� *
WeightUnit+  5#      $ Цена��6%   $
 0.5* 63    6@   �� *Price+ �� StringFormat$ {0}₽��4  .System.Windows.Controls.DataGridTemplateColumn  5$      $ Сертификат��6)   	   CellTemplate	 5%      �� 5&      .R�5'      �� $��BtnCertificate��6%   -   5          PColor_Second#��[ 5'   }     PColor_Black#��[ 5(   %   $
��10 3q�6P   $
��auto��6_   
�������$��1q�6   
 � ToolTip$
 Просмотреть��6�   ��5'   X   �� *CertificateState+5(   �   5)      5+        5,      	 5-      �� 5.      .R�5/      �� $��BtnEdit��6%   -   5        $ ��Редактировать��5/   J   $
��10 3q�6b   $
��auto��6q   50      52        53      	 54      �� 55      .R�56      �� $��	BtnDelete��6%   -	   5        $��Удалить��56   N   $
��auto��6`   $
��10 3q�57   %   #��[ 64   58      5:      5<      �� 5>   
   -
   5        $��BtnAdd��5?   2   $��2��5>      $��Right=�6   $��0 0 15 5q�6:   $
��auto��6L   $
��20 5q�6Y   $0��*Добавить новый продукт��5?      $��Center=�6@   6[   5A      5B      