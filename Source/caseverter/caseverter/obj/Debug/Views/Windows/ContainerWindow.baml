   M S B A M L   `   `   `  ����E  Acaseverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:caseverter
caseverter  5   	        caseverter.ContainerWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:caseverter     5   	   -   5          �Name$  Window��5   	    � Title$ 
caseverter��5	   	   $	��520��5
   	   $	��224��5   	    � 
ResizeMode$ CanMinimize=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    J� SnapsToDevicePixels .  � Topmost .  � 	Resources 5          caseverter.ContainerWindow	 �� 
TargetType'  !System.Windows.Shell.WindowChrome
 �� Property �� Value   CornerRadius   GlassFrameThickness   CaptionHeight �� 
TargetType �� Padding   
BlackBrush �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity ��Name J� OpacityMask !� Visual �� ElementName � RowDefinitions �� FallbackValue K� ZIndex � ColumnDefinitions  TitleBarButtonStyle  GearIcon �� BitmapScalingMode �� Orientation  CaseverterLogo  
WhiteBrush  MinimizeIcon  WindowCloseButtonStyle  	CloseIcon��%�  '        7   7   7  7  7  7  7  7  7  7  7  �� 5   
   "	  6   .�5      �� 
 �@ WindowChrome 5        5      $ 0��5   #   $ 0q�5   #    5   #   �� *TitleBarHeight+5   #   5      �� 5       
 � �� 5!      �� 5"      " �6&   .R�5%      ��  6!   �� *ShadowMarginThickness+._�5(      � .+�5-   "   �� 8��   5.   )   �� *WindowCornerRadius+ 51   &     52   *   $ 0Q�6;   $	 0.3Q�6K   55   #   �� 5:   "   $
 Mask��6)   8��  5<   )   �� *WindowCornerRadius+� 5?   "    5C   &   !� 5D   *    66   �� $
 Mask�� 5M   &   �� 5P   *   ��68   �� *TitleBarGridHeight+$ 32���� 5S   *   $��* �68   .+�5^   &   � $ 1��6+    5b   *   �� 5e   .   $
��Auto �6?   �� 5h   .   $��* �6?   �� 5k   .   $
��Auto �6?   .+�5u   *   �� 8�� ��61   �� *SettingsCommand+.��5v   .   �� 8�� $ HighQuality=�6W    . 6�   5w   +   (� 5~   *   $��1��62   .��5   .   �� $ 
Horizontal=�69   $��2q�6R   .+�5�   2   �� 8�� $��7��6a   $ HighQuality=�6k    . 6�   �� 5�   2   $	��ase��6<   8�� $��Medium"�6p   $��0.25 0 0 1.55q�6�   �� 5�   2   $��verter��6<   8�� $��Light"�6s   $��
0 0 0 1.55q�6�   5�   /   5�   +   �� 5�   *   $ 
Horizontal=�65   $��2��6N   .+�5�   .   �� 8�� ��65   �� *MinimizeCommand+.��5�   2   �� 8�� $ HighQuality=�6_    . 6�   5�   /   �� 5�   .   8��	 ��65   �� *CloseCommand+.��5�   2   �� 8��
 $ HighQuality=�6\    . 6�   5�   /   5�   +   5�   '   �� 5�   &   $��1��6-   }�. ._�5�   *   �� #��z��6;   5�   '   5�   #   5�      5�      5�      5�      5�      5�      .��5�      � .+�5�   
    � -   5          �Name$ ContentFrame��5�         � NavigationUIVisibility$  Hidden=�5�      ��5�      �� *" ApplicationViewModel.CurrentPage+!   caseverter.ViewModelLocator!   Instance" �� Source#" Z! # �� 	Converter# /   )caseverter.ApplicationPageToPageConverter  5�      5�      5�      