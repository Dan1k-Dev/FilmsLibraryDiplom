   M S B A M L   `   `   `  ����H  DFrolov_Cinema, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Frolov_Cinema.PagesFrolov_Cinema.Pages  5   	   -    'Frolov_Cinema.Pages.OperationFilmsAdmin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Frolov_Cinema.Pages     5   	     � Title$  Управление��5   	   $	��800��6   $	��900��6)    � Icon$ /Resources/Logo.ico��5	   	    � WindowStartupLocation$ CenterScreen=�6$   $	��800��5
   	   $	��900��6   .��5      � ���	#FF110203 � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��2.8* �6    � RowDefinitions 5   
   �� 5      $	��60* �6   �� 5      $	��90* �6   �� 5      $
��410* �6   �� 5      $	��60* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��4��6,   $��0��5      .+�5      �� $��	Kinolenta��6      text#���   6)   $��Center=�5      $��Center=�63   $��0 20 0 0q�5      $��32(�6*   �� 5      -   5         ��Name$ 	Filmotech��5   *   $��Фильмотека��6     
mainbutton#���  5   .   $��0 20 0 0q�5       $��16(�6'   �� 5!      -   5        $ UserCabinet��5!   .   $!��Личный кабинет��6   #���  5"   0   $��0 20 0 0q�5#      $��16(�6'   �� 5$      -   5        $ Manage��5$   *   $��Управление��6   #���  5%   +   $��0 20 0 0q�5&      $��16(�6'   �� 5'      -   5        $ History��5(   5   $��История��5'      #���  6'   $��0 20 0 0q�5(      $��16(�6'   5)      �� 5*      -   5        $ Review��5+   5   $!��Оставить отзыв��5*      #���  6.   $��0 20 0 0q�5+      $��16(�6'   5,      �� 5-      -   5         ��Name$ ParamAccess��5-      $�� ��6)   $y�Hidden=�64   �� 5.      -   5        $ ExitBtn��5.      $��
Выход��5/   +     exitRed#���  6;   $��Bottom=�50      $��Center=�60   $��0 0 0 0q�51      $	��200��6&   $��16(�62   52      53      �� 55   
   $��1��6   $��0��6%   $ 
Horizontal=�62   .+�56      �� 
�������$��1q�6)    �� CornerRadius$ 5��57      $��10q�6&   ._�58      �� -   5        	 ��Name$	 	SearchBar��58      $�� ��6-    
 txtBox#���  59      $��30��5:   >   $	��530��5;      $��20(�6&   
 �� 
CaretBrush

 �����64   5<      5=      �� 5?   
   $��1��6   $��1��6%   $ 
Horizontal=�62   .+�5@      �� $��Категории:��6   #���   6*   $��17(�5A      $��
20 -50 0 0q�6&   �� 5B      -	   5         ��Name$ CatgCb��5B        ComboboxStyle#���  6'   $	��200��5C      $��
10 -40 0 5q�6#   $��40��67   5D      5E      �� 5H   
   $��1��6   $��2��6%   $ Vertical=�62   $	��640��5I      .+�5J      �� -
   5         ��Name$ FilmsLB��5K   ?   
�������$��25(�5J   )   
������ $��Arial)�5K      $��DemiBold"�6)   $��Disabled=�5M      $��Visible=�5N      $��10q�5O      $	��490��6"   ��5P      �� 5Q      .R�5R      �� .+�5S      ��  ��Name$ FilmsImg��6$   $	��150��66   $	��150��5T   $   $
��Left=�5U   $   ��5T   0   ��  �� Path$ Imagge�5U   $   �� 5V       ��Name$ FilmsN��6(   $
��Wrap=�68   
�������$��Right=�5X   (   ��5W       �� $
 Name�5X   (   5Y      5Z      5\      5]      �� 5_   
   $��1��6   $��3��6%   $ 
Horizontal=�62   .+�5`      �� -   5        $ DelFilm��5b   *   #���  5`      $��Удалить��5a      $��Right=�6'   $��130 10 0 10q�5b      5c      �� 5d      -   5        $ AddFilm��5f   )   #���  5d      $��Добавить��5e      $��Right=�6(   $��
20 10 0 10q�5f      6:   5g      5i      5j      