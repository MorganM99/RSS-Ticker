   M S B A M L   `   `   `  ����E  ARSS Ticker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RSS_Ticker_Release.PropertiesRSS_Ticker_Release.Properties  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   7 clr-namespace:RSS_Ticker_ReleaseRSS_Ticker_Release  5   	   !    RSS_Ticker_Release.Settings   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   B
properties+clr-namespace:RSS_Ticker_Release.Properties     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   2local clr-namespace:RSS_Ticker_Release     5   	   -   5          � Title$  Settings��5
   	   $	��700��6   $
��1100��6'   $	��700��64   $
��1100��6D    � 
ResizeMode$ CanMinimize=�5   	    � 	Resources 5         CheckBoxCell d� 	IsChecked �� Path �� RelativeSource �� AncestorType  CheckBoxListviewStyle �� 
TargetType �� 	Resources	 �� Color
 �� Property �� Value��%k  &	        &	 f     �� 5   
   .R�5      ��  6   �� $ 
IsSelected� �� *FindAncestor+" ��5      �� 5   
   " ��6.    5      ���� 5      $	 White��5      (��       5   "   * SystemColors.HighlightBrushKey+)5      �� 5      $	 White��5      (��       5   "   *SystemColors.ControlBrushKey+)5      �� 5      $	 Black��5      (��       5   "   *$"SystemColors.HighlightTextBrushKey+)5      �� 5      $	 Black��5      (��       5   "   *" SystemColors.ControlTextBrushKey+)5      5       .�5!      �� 
 � |� .  6*   5"      5%      .��5'      � $	��700��6   $
��1100��6   $	��700��6%   $
��1100��65   .+�5*   
   �� .@�5,      �� ��5.      �� 5/      $��News sources��6    66   .��53      �� $��0,0,6,28q�6   .+�55      � $
��Left=�6   $	��700��66   $
��1094��6C   $	��700��6P   $
��1100��6`    � ColumnDefinitions 57      �� 58      $
��900* �6/   �� 59      $
��200* �6/   .+�5<      �� -   5        $��	sourceInp��5<   =   $
��Left=�6"   $��36��6N   $��36��6Z   $��
10,600,0,0q�6i    �� TextWrapping$
 Wrap=�5=   "   $!��Input new news sources here��66   $	��Top=�6Y   $	��617��6q   $	��617��5>   "   
�������6u   �� 5B      -   5        $��
addFeedBtn��5D   L   $��30��5B   !   $	��150��6-   $��30��69   $	��150��6H   $��645,600,0,0q�6W   $
��Left=�5C   !   $	��Top=�6<   $��Add feed to list��5D   !   6L   �� 5F      -   5        $��Delete all selected��5F   !   $��30��6?   $��30��6K   $	��150��6Z   $	��150��5G   !   $
��Left=�60   $	��Top=�6K   $��
26,600,0,0q�5H   !   $��1��65   6E   �� 5J      -   5        $��1��5J   !   $��Save changes and exit��61   $��30��6Q   $��30��6]    � ToolTip$ Saves settings and exits��5K   !   $	��150��5L   !   $	��150��6-   $
��Left=�6<   $	��Top=�6W   $��
26,471,0,0q�5M   !   65   5P      �� 5S      -   5         ��Name$ feedList��5S   g   $��0��6   $	��900��6/   $	��592��6;   $	��592��6H   $	��900��6X   #���  5T       �� SelectionMode$ Extended=�6\    �� View 5W      �� 5Z      .P�5\   "   �� $��News Source��61    �� Width$	 800��6F    �� CellTemplate 5]   &   �� 5^   *   .R�5_   .   �� $��NoWrap=�68   �� 5`   2   -   5        ��5`   <   �� .�6o   .�5a   .   �� ��68   �� 5b   3   5e   )   5f   +   5h   #   �� 5j   "   $��Delete?��61   # [  6B   $	 100��6o   6}   5l      5o      5p      5q      �� 5t      ��5u      �� 5v      $��Other Settings��6    .��5x      � $
��Left=�6   $	��700��63   $
��1100��6@   $	��700��6M   $
��1100��6]   .+�5z      �� $
��Left=�6    $��19��6;   $��	10,10,0,0q�6G   $
��Wrap=�6Z   $6��0NOTE: All settings here are applied immediately.��5{       $	��Top=�6X   $
��1068��6p   �� 5}      $
��Left=�6    $��	10,34,0,0q�6;   $
��Wrap=�6N   $Q��KTo save these settings, you must still select "Yes" when closing the winodw��5~       $	��Top=�5       $
��1080��68   �� 5�      $
��Left=�6    $��22��6;   $��22��6G   $��	10,80,0,0q�6V   $
��Wrap=�5�      $	��Top=�5�      $	��345��66   $	��345��6E   �� 6R   $=�7Font Size: Change the font of scrolling text using the ��6V   �� 6�   $�	box below��6�   6�   �� 5�      $
��Left=�6   $��27��6:   $��
10,107,0,0q�6F   $	��Top=�6Z   $	��345��6r    �� SelectedItem 5�      �� ,  &RSS_Ticker_Release.Properties.Settings   Default �� Source# Z $ 
tickerFont� �� Mode$ TwoWay=�.@�5�      ��12��6(   ��5�      14��6(   ��5�      16��6(   ��5�      18��6(   5�      �� 5�      $
��Left=�6    $��35��6;   $��
632,67,0,0q�6G   $
��Wrap=�6[   $]��WRefresh Time: Change the time between refreshes of the ticker in minutes using this box��5�       $	��Top=�5�       $	��345��68   �� 5�      $��27��6   $	��345��6+   $��632,107,123,566q�67    5�      �� # Z $ refreshTime�$ TwoWay=�.@�5�      ��20��6(   ��5�      30��6(   ��5�      40��6(   ��5�      50��6(   ��5�      60��6(   5�      �� 5�      $
��Left=�6    $��34��6;   $��
10,269,0,0q�6G   $
��Wrap=�6[   $\��VDocking Edge: Change which part of the screen the ticker will reside in using this box��5�       $	��Top=�5�       $	��345��68   �� 5�      $
��Left=�6   $��27��6:   $��
10,308,0,0q�6F   $	��Top=�6Z   $	��345��6r    5�      �� # Z $ dockEdge�$ TwoWay=�.@�5�      ��
Bottom��6-   ��5�      Top��6*   5�      �� 5�      $
��Left=�6    $��35��6;   $��632,268,0,0q�6G   $
��Wrap=�6\   $	��Top=�6p   $	��348��6�   �� 5�      $i�cScrolling Speed: Change the speed the ticker will scroll news at using this box, as a percentage of��6    �� 5�      $� ��6   �� 6)   $� a fixed value��6-   6F   �� 5�      $
��Left=�6   $��27��6:   $��632,308,0,0q�6F   $	��Top=�6[   $	��345��6s    5�      �� # Z $ tickerSpeed�$ TwoWay=�.@�5�      ��50%��6*   ��5�      75%��6*   ��5�      100%��6+   ��5�      150%��6+   ��5�      200%��6+   5�      �� 5�      -   5        $��Save and Exit��5�      $
��Left=�65   $��44��6P   $��44��6\   $��
24,587,0,0q�5�      $	��Top=�61   $	��197��6I   $	��197��6U   $ Saves changes and exits��5�      5�      5�      5�      5�      5�      5�      