   M S B A M L   `   `   `  ���� E  ARSS Ticker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:RSS_Ticker
RSS_Ticker      RSS_Ticker.watchLater   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:RSS_Ticker     -     � Title$  
watchLater��$	��700��$
��1100��$	��700��$
��1100�� � 
ResizeMode$ CanMinimize=� � 	Resources    CheckBoxCell d� 	IsChecked �� Path �� RelativeSource �� AncestorType  CheckBoxListviewStyle �� 
TargetType �� 	Resources	 �� Color
 �� Property �� Value��%�  &	        &	 F     �� .R���  �� $ 
IsSelected� �� *FindAncestor+" ���� " �� ���� $	 White��(��       * SystemColors.HighlightBrushKey+)�� $	 White��(��       *SystemColors.ControlBrushKey+)�� $	 Black��(��       *$"SystemColors.HighlightTextBrushKey+)�� $	 Black��(��       *" SystemColors.ControlTextBrushKey+).��� 
 � |� .  .���� .+�� $
��Left=�$	��615��$
��1000��$	��615��$
��1000�� � ColumnDefinitions �� $��1000* ��� -    ��Name$ itemList��$��0��$
��1050��$	��615��$	��615��$
��1050��#���   �� SelectionMode$ Extended=� �� View �� .P��� $��Title�� �� Width$	 250�� �� DisplayMemberBinding �� *Title+�� $��Description��$	 250�� �� *Description+�� $
��Link��$	 230�� �� CellTemplate �� .R��� $��NoWrap=��� -   ���� *Link+.�.��� ���� *Link+�� $��Publication Date��$	 150�� �� *	PubDate+�� $��Rating��$ 90�� �� *Rating+�� $��Delete?��# [  $ 90���� -   $��Delete all selected��$��39��$��39��$	��193�� �� Left$ 29��
 �� Top$	 620��$	��193���� -   $��Save database and exit��$��39��$��39��$	 857��$	 620��$	��193��$	��193��