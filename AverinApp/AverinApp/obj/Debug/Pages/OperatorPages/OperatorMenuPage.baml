   M S B A M L   `   `   `  ����D  @AverinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AverinApp.EntitiesAverinApp.Entities  5      4    .AverinApp.Pages.OperatorPages.OperatorMenuPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:AverinApp.Entities     5      -   5          N� Title$/  )Оператор. Главное меню��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Center=�6      TbkBody#��[  61   $	��Top=�6l   $��30(�6�   $��0 20 0 0q�6�   ��6R   �� *
Greeting+6�   �� 5   
   $��1��6   $��Center=�6"   .+�5      � .+�5      �� -   5        $��	BtnSupply��5      $��Center=�6B   $��26(�6f   $
��auto��6t   $
��30 2q�6�   .��5      �� -   5        $��TbkOfBtnSupply��5   `   $;��5Отгрузка товаров
 на склад №0��6     �� TextAlignment$ Center=�6I   6`   5      �� 5      -   5        $��BdrSupplyCount��5        PColor_First#��[ 6/    �� CornerRadius$	 100��6Z   $��Right=�6m   $	��Top=�5      $��30��61   $��30��6<   $y�Hidden=�6H   ._�5      �� -   5        $��TbkSupplyCount��5   A   #��[  6    $��0��6W   
�������$��12(�6s   $ Center=�6�   5      5      �� 5      -   5        $��BtnShipment��5      $��26(�6B   $��Right=�6P   $
��auto��6s   $
��30 2q�6�   .��5      �� -   5        $��TbkOfBtnShipment��5   \   $<��6Отправка товаров
со склада №0��6   $ Center=�6E   6\   5       �� 5!      -   5        $��	BtnReport��5!      $��
Отчёт��6>   $��26(�6N   $
��auto��6\   $
��30 2q�6i   5"      �� 5$   
   -	   5        $��TbkErrorMessage��5%      $��2��5$      $	��Top=�6!   $J��DВы не назначены ни на один из складов!��69   $��Center=�6g   $
��0 15q�5%   +   $y�	Collapsed=�69   $��26(�6P   #��[  6^   5'      5(      