   M S B A M L   `   `   `  ����H  DFrolov_Cinema, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Frolov_CinemaFrolov_Cinema  5          Frolov_Cinema.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -localclr-namespace:Frolov_Cinema     5        �� 	Resources  5         
mainbutton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Triggers P� Property	 P� Value  text 
 txtBox  	buttonReg  regGreen
 �� BasedOn  exitRed  ComboboxButtonStyle ��Name  ComboboxTextBlockStyle ��Name  ComboboxStyle � ColumnDefinitions �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource �� SelectionBoxItem �� SelectionBoxItemTemplate �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation��%�  &	        &	     &	 �    &	 �    &	 b    7  &	 i    7  &	 l	    &	 �
    &	 �    7  7  �� 5	   
   " ��6#   .�5
      ��  � ��$ 14(�6)   �� 5       � ��$	 200��6&   �� 5       � ��$ 0 20 0 0q�6'   �� 5       � ��
 ���� 6+   �� 5       � ��
 �����6+   �� 5       �@�FocusVisualStyle 61   Z� �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 15��6L   $��1q�6^   
�������$ 15q�5   5   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver	 . . �5      ��  � ��
 �����63   �� 5       � ��
 �   �63   5      P� 5        �@J�IsMouseCaptured	 . . �5!      ��  � ��
 �����63   �� 5"       � ��
 �   �63   5#      5%      �� 5)   
   " ��6   .�5*      ��  � ��
 �����6+   �� 5+       � ��$ DemiBold"�6+   �� 5,       � ��$ 28(�6)   �� 5-       � ��$ Center=�62   5.      �� 52   
   " ��6   .�53      ��  � ��$ 14(�6)   �� 54       � ��$ 1��6,   �� 55       � ��$ 10 0 0 0q�6'   �� 56       � ��
 �����6+   �� 57       � ��
 ���� 6,   �� 58       � ��
 ���� 6+   �� 59       � ��$ 0q�60   5:      �� 5>   
   " ��6"   .�5@      ��  � ��
 ���� 6+   �� 5A       � ��
 �����6+   �� 5B       � ��$ 0q�60   �� 5C       � ��$ 50��6&   �� 5D       � ��$ 16(�6)   �� 5E       � ��$ SemiBold"�6+   �� 5F       � �� 5G      �� 5H      " ��6&   .R�5I      �� #��z��6!   $ 5��6K   $ 5q�6\   
�������$��1q�6|   ._�5J      �� $��Center=�6/   $��Center=�6L   5K      5L      5N       5P      P� 5Q       �@J�IsMouseOver	 . . �5R      ��  � ��
 �����63   �� 5S       � ��
 �   �63   5T      5V      �� 5X   
   " ��6!   8
   .�5Z      ��  � ��
 ���� 6+   �� 5[       � ��
 �����6+    5\      P� 5]       �@J�IsMouseOver	 . . �5^      ��  � �� �#5fe7c463   �� 5_       � ��
 �����63   5`      5b      �� 5f   
   " ��6    8
   .�5g      ��  � ��
 ���� 6+   �� 5h       � ��
 �����6+    5i      P� 5j       �@J�IsMouseOver	 . . �5k      ��  � ��
 �  ��63   �� 5l       � ��
 �����63   5m      5o      �� 5s   
   " d�6,   .�5t      ��  �@�Cursor$
 Hand��6'   �� 5u       � ��$ Trebuchet MS)�6+   �� 5v       � �� 5w      �� 5x      " d�6&   .R�5y      �� $ border��5z      $ 	0,15,15,0��5{      #��z��5|      $��0,1,1,1q�5}      
���   �._�5      �� 5�      5�      5�      5�      �� 5�   
   " ��6/   .�5�      ��  � �� 5�      �� 5�      " ��6&   .R�5�      � .+�5�      �� $ 	15,0,0,15��6%   $��1,1,0,1q�5�   !   #��z��5�   !   
���   �._�5�   "   �� $ PART_ContentHost��6/   5�      5�      5�      5�      5�      �� 5�   
   " ��6&   .�5�      ��  �@�Cursor$
 Hand��6'   �� 5�       � ��$ Trebuchet MS)�6+   �� 5�       � ��
 �   �6+   �� 5�       � ��$ Center=�6;   �� 5�       � ��$ Center=�69   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �  5�      �� 5�   "   �� 5�   "   $��18��63   .+�5�      �� $��PART_EditableTextBox��6&   8��  $��5,0,0,0q�5�   !   $��0 0 0 0q�5�   !   #��z��5�   !   #��z��5�   !   $y�Visible=�5�   "   d� 5�      $��1��6+   $��0q�6;   #��z��5�   !   8�� |�.  #��z��5�   !   $ Release=�5�   !    5�   !   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+.��5�   "   F� $��1��6'   $��Center=�5�   %   $��Center=�5�   %   "����        � 	=  	= � z     	
���   �5�   %   5�      �� 5�      $��ContentSite��6/   #��z 5�   !   #��z 5�   !   #��z��5�   !   $��Center=�5�   !   $
��Left=�5�   !   $��5,0,0,0q�5�   !   � 5�      $��Popup��6$   $��Bottom=�5�   !   #��z 5�   !    . |�.  $��Slide=�5�   !   .��5�   "   � $��DropDown��6'    . #��z 5�   %   #��z 5�   %   #��z��5�   %   .+�5�   &   �� $ DropDownBorder��5�   )   $��1q�5�   )   $ 5��5�   )   
���   �#��z��5�   )   �� 5�   &   $��4,6,4,6q�63    . .��5�   *   ��  . $ 	Contained=�6H   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      