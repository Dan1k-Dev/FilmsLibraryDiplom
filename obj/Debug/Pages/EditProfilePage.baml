   M S B A M L   `   `   `  ����H  DFrolov_Cinema, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Frolov_Cinema.PagesFrolov_Cinema.Pages  5   	   )    #Frolov_Cinema.Pages.EditProfilePage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Frolov_Cinema.Pages     5   	     � Title$"  Редактирование��5   	   $	��350��6    $	��400��6-   $	��350��69   $	��400��5	   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$
 None=�5
   	    � Icon$ /Resources/Logo.ico��6   .��5      � ���	#FF110203.+�5   
   �� -   5         ��Name$ BackBtn��5         
mainbutton#���   5      $	��←��66   $��50��5      $��50��6   $	��Top=�6(   $
��Left=�5      $��10 5 0 0q�6,   5   "   �� 5   
   $��1��6   $��0 30 0 0q�6"   .+�5      �� $��1q�6   
�������$��
50 60 50 7q�6=    �� CornerRadius$ 5��5      ._�5      �� -   5         ��Name$ Nickname��5       
 txtBox#���  6,    �� 
CaretBrush
 �����$��
Логин��5   )   $��9,2,3,1q�66   $��18(�6G   .��5   G   5      5      �� 5      $��1q�6   
�������$��
50 20 50 7q�6=   $ 5��5      ._�5      �� -   5        $ Email��5      #���  6)   
 �����$��
Почта��5   )   $��6 2 6 1q�66   $��18(�6G   .��5   D   5      5       �� 5!      $��1q�6   
�������$��
50 20 50 7q�6=   $ 5��5"      ._�5#      �� -   5        $ Password��5#      #���  6,   
 �����$��Пароль��5$   )   $��6 2 6 1q�67   $��18(�6H   .��5%   G   5&      5'      �� 5(      -   5        $
 Okay��5(        regGreen#���  6#   $��Принять��6F   $��18(�5)      $��
Bahnscrift)�6#   $��Bottom=�6;   $��Center=�5*      $	��100��62   $��0 20 0 0q�5+      5,      �� 5-      -   5         ��Name$ ParamAccess��5-      $�� ��6)   $y�Hidden=�64   5.      50      51      