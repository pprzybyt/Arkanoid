   M S B A M L   `   `   `  ����  Arkanoid    Arkanoid.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5        $��window��5   	     � Title$  Arkanoid��6   $	��500��6(   $	��400��65    � 
ResizeMode$ NoResize=�6A    � WindowStartupLocation$ CenterScreen=�6W   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ Black��6    � Offset$ 0Q�6)   � 5      $ 	#FF71DE48��6   $ 0.635Q�6-   5	      .��5      � -   5        $
��grid��5      $	��394��6   $	��470��6#   $��0,0,0,0q�60   .+�5   
   �� -   5        $
��ball��5   =   $y�Hidden=�6   $��100,150,0,0q�6(    �� RadiusX$	 120��6J    �� RadiusY$	 120��6X   
���   �$��25��6s   $��25��6   $	��Top=�6�   $
��Left=�6�   6�   �� 5   
   -   5        $��block��5   /   $	��Top=�6�   $
��Left=�6�   $��5��6�   $y�Hidden=�6�   ��6   �� *Margin+��6<   �� *Brush+��6U   �� *Height+��6o   �� *Width+6�   �� 5   
   -   5        $	��pad��5   X   $y�Hidden=�6   $��10��6*   $ 30��66   $��100,440,0,0q�6C   
���   �$	��Top=�6r   
���   �$
��Left=�6�   $	��100��6�   �� 5   
   -   5        $��startButton��5      $��START��6%   $��	48,75,0,0q�65   $	��300��6H   $	��100��6T   $��36(�6v   $��Gill Sans Ultra Bold)�6�   $
��Bold"�6�   $
��Left=�6�   $	��Top=�6�   ��5      �� 5      $ 0.5,1&�6&   	 � MappingMode$	 RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5      � $ 	#FFF3F3F3��6#   � 5      $ 	#FFEBEBEB��6#   $	 0.5Q�65   � 5      $ 	#FFDDDDDD��6#   $	 0.5Q�65   � 5      $ 	#FF63B85B��6#   $ 1Q�65   5      5      �� 5   
   -   5        $��
scoreLabel��5      $��SCORE:��6"   $
��Left=�63   $��38��6N   $��
48,302,0,0q�6Z   $	��Top=�6n   $��82��6�   $��Showcard Gothic)�6�   $��22(�6�   $y�Hidden=�6�   �� 5   
   -   5        $��scoreBox��5      $
��Left=�6$   $��269,302,0,0q�6?   $
��Wrap=�6T   $	��Top=�6h   $��38��6�   $��79��6�   $��Showcard Gothic)�6�   $��22(�6�   $y�Hidden=�6�   �� 5   
   -	   5        $��continueLabel��5      $��Press SPACE to continue��6%   $
��Left=�6G   $��49��6b   $��
10,149,0,0q�6n   $	��Top=�6�   $	��374��6�   
 J� RenderTransformOrigin$
 0.514,-3.343&�6�   $��Gill Sans Ultra Bold)�6�   $��21(�6�   $y�Hidden=�6�   �� 5   
   -
   5         ��Name$ highScoreButton��5      $��HIGH SCORES��6*   $
��Left=�6@   $��
48,175,0,0q�6[   $	��Top=�6o   $	��300��6�   $	��100��6�   $
 	0.57,1.01&�6�   $��30(�6�   $��Gill Sans Ultra Bold)�6�   $
��Bold"�6�   ��5   
   �� 5       $ 0.5,1&�6"   $	 RelativeToBoundingBox=�63   $ 0.5,0&�6W   .��5!      � $ 	#FFF3F3F3��6   � 5"      $ 	#FFEBEBEB��6   $	 0.5Q�61   � 5#      $ 	#FFDDDDDD��6   $	 0.5Q�61   � 5$      $ 	#FF63B85B��6   $ 1Q�61   5%      5'      �� 5(   
   -   5        $ aboutButton��5(      $��ABOUT��6&   $
��Left=�66   $��
48,275,0,0q�6Q   $	��Top=�6e   $	��300��6}   $	��100��6�   $
 	0.57,1.01&�6�   $��30(�6�   $��Gill Sans Ultra Bold)�6�   $
��Bold"�6�   ��5)      �� 5*      $ 0.5,1&�6&   $	 RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5+      � $ 	#FFF3F3F3��6#   � 5,      $ 	#FFEBEBEB��6#   $	 0.5Q�65   � 5-      $ 	#FFDDDDDD��6#   $	 0.5Q�65   � 5.      $ 	#FF63B85B��6#   $ 1Q�65   5/      51      52      54      