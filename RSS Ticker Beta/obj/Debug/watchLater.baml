   M S B A M L   `   `   `  ����E  ARSS Ticker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:RSS_Ticker_ReleaseRSS_Ticker_Release  5   	   #    RSS_Ticker_Release.watchLater   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:RSS_Ticker_Release     5   	   -   5          � Title$  
watchLater��5   	   $	��700��6   $
��1100��6)   $	��700��66   $
��1100��6F    � 
ResizeMode$ CanMinimize=�5	   	    � 	Resources 5         CheckBoxCell d� 	IsChecked �� Path �� RelativeSource �� AncestorType  CheckBoxListviewStyle �� 
TargetType �� 	Resources	 �� Color
 �� Property �� Value��%k  &	        &	 f     �� 5   
   .R�5      ��  6   �� $ 
IsSelected� �� *FindAncestor+" ��5      �� 5   
   " ��6.    5      ���� 5      $	 White��5      (��       5   "   * SystemColors.HighlightBrushKey+)5      �� 5      $	 White��5      (��       5   "   *SystemColors.ControlBrushKey+)5      �� 5      $	 Black��5      (��       5   "   *$"SystemColors.HighlightTextBrushKey+)5      �� 5      $	 Black��5      (��       5   "   *" SystemColors.ControlTextBrushKey+)5      5      .�5       �� 
 � |� .  6*   5!      5%      .��5(      �� .+�5*   
   � $
��Left=�6   $	��615��6*   $
��1000��67   $	��615��6D   $
��1000��6T    � ColumnDefinitions 5+      �� 5,      $��1000* �6#   5.      �� 51   
   -   5         ��Name$ itemList��51   ]   $��0��6   $
��1050��6#   $	��615��60   $	��615��6=   $
��1050��6M   #���  52       �� SelectionMode$ Extended=�6T    �� View 55      �� 58      .P�5;      �� $��Title��6%    �� Width$	 250��64    �� DisplayMemberBinding 6@   �� *Title+�� 5=      $��Description��6%   $	 250��6:    6F   �� *Description+�� 5A      $
��Link��6%   $	 230��63    �� CellTemplate 5B      �� 5C      .R�5D   "   �� $��NoWrap=�6,   �� 5E   &   -   5        ��5E   0   �� *Link+.�6h   .�5F   *   �� ��64   �� *Link+5G   '   5H      5I      5K      �� 5N      $��Publication Date��6%   $	 150��6?    6K   �� *	PubDate+�� 5O      $��Rating��6%   $ 90��65    6@   �� *Rating+�� 5Q      $��Delete?��6%   # [  66   $ 90��6c   6p   5T      5X      �� 5Z   
   -   5        $��Delete all selected��5Z      $��39��6/   $��39��6;   $	��193��6J    �� Left$ 29��5[      
 �� Top$	 620��6"   $	��193��63    � ToolTip$/ )Deletes all checkmarked items in the list��5\      �� 5_   
   -   5        $��Save database and exit��5_      $��39��62   $��39��6>   $	 857��6M   $	 620��5`      $	��193��6"   $	��193��6.   $- 'Saves changes to the database and exits��5a      5d      5e      