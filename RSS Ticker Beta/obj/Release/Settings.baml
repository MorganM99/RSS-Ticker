   M S B A M L   `   `   `  ���� E  ARSS Ticker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RSS_Ticker.PropertiesRSS_Ticker.Properties  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 'clr-namespace:RSS_Ticker
RSS_Ticker      RSS_Ticker.Settings   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :
properties#clr-namespace:RSS_Ticker.Properties     6sys&clr-namespace:System;assembly=mscorlib     *localclr-namespace:RSS_Ticker     -     � Title$  Settings��$	��700��$
��1100��$	��700��$
��1100�� � 
ResizeMode$ CanMinimize=� � 	Resources    CheckBoxCell d� 	IsChecked �� Path �� RelativeSource �� AncestorType  CheckBoxListviewStyle �� 
TargetType �� 	Resources	 �� Color
 �� Property �� Value��%�  &	        &	 F     �� .R���  �� $ 
IsSelected� �� *FindAncestor+" ���� " �� ���� $	 White��(��       * SystemColors.HighlightBrushKey+)�� $	 White��(��       *SystemColors.ControlBrushKey+)�� $	 Black��(��       *$"SystemColors.HighlightTextBrushKey+)�� $	 Black��(��       *" SystemColors.ControlTextBrushKey+).��� 
 � |� .  .��� $	��700��$
��1100��$	��700��$
��1100��.+��� .@��� ���� $��News sources��.���� $��0,0,6,28q�.+�� $
��Left=�$	��700��$
��1094��$	��700��$
��1100�� � ColumnDefinitions �� $
��900* ��� $
��200* �.+��� -   $��	sourceInp��$
��Left=�$��36��$��36��$��
10,600,0,0q� �� TextWrapping$
 Wrap=�$!��Input new news sources here��$	��Top=�$	��617��$	��617��
��������� -   $��
addFeedBtn��$��30��$	��150��$��30��$	��150��$��645,600,0,0q�$
��Left=�$	��Top=�$��Add feed to list���� -   $��Delete all selected��$��30��$��30��$	��150��$	��150��$
��Left=�$	��Top=�$��
26,600,0,0q�$��1���� -   $��1��$��Save changes and exit��$��30��$��30��$	��150��$	��150��$
��Left=�$	��Top=�$��
26,471,0,0q��� -    ��Name$ feedList��$��0��$	��900��$	��592��$	��592��$	��900��#���   �� SelectionMode$ Extended=� �� View �� .P��� $��News Source�� �� Width$	 800�� �� CellTemplate �� .R��� $��NoWrap=��� -   ���� .�.��� ���� �� $��Delete?��# [  $	 100���� ���� $��Other Settings��.��� $
��Left=�$	��700��$
��1100��$	��700��$
��1100��.+��� $
��Left=�$��22��$��22��$��	10,10,0,0q�$
��Wrap=�$F��@Font Size: Change the font of scrolling text using the Box Below��$	��Top=�$	��345��$	��345���� $
��Left=�$��27��$��	10,37,0,0q�$	��Top=�$	��345�� �� SelectedItem �� $  RSS_Ticker.Properties.Settings   Default �� Source# Z $ 
tickerFont� �� Mode$ TwoWay=�.@���14����16���� -   $��Save and Exit��$
��Left=�$��44��$��44��$��
24,587,0,0q�$	��Top=�$	��197��$	��197��