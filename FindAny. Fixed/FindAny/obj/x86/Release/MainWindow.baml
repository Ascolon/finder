   M S B A M L   `   `   `  ����   FindAny    FindAny.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Найди отличия��$	��670��$
��1130�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.���  � RowDefinitions �� $��50 ��� .+�r� -   $��Audio��$��1��$��1�� r� LoadedBehavior$ Manual=� r� IsMuted .   r� Volume$ 1Q� r� Source$$ View/Data/Audio/levelMusic.mp3?�� -   $��MainMenu��$��0�� K� ZIndex$ 1��$y�	Collapsed=�	 � ColumnDefinitions	 �� $	��40* ��� $	��40* ��� $	��40* �.+��� -   $��Player��$��Игрок: ��$��30,0,0,0q�$��Segoe UI)�$��20(�
���Gc��$��Center=�$��0���� 
 �� Orientation$
 
Horizontal=�$��Right=�.+��� -   $��	ScoreGame��$��
Очки: ��$��0,0,0,0q�$��Segoe UI)�$��20(�
���Gc��$��Center=�$��0���� $
 
Horizontal=�$��1��$��Center=����	#50000000$	��150��.+��� -   $��	TimerText��$��0,0,0,0q�$��30(�$	��150�� �� TextAlignment$ Center=�$��Center=�$��Segoe UI)�$��Center=�
�������$��
ExtraLight"�$��0���� $
 
Horizontal=�$��2��.+��� -   $��2��$��30��$	��160��$��20(�$��0,0,0,0q�$��Segoe UI)� � Cursor$
 Hand�����#841000$��Light"�$��Right=�$#��сменить уровень�� 
  Corner#��[  �� -   $��2��$��30��$	��120��$��20(�$��10,0,0,0q�$��Segoe UI)�$
 Hand�����#841000$��Light"�$��Right=�$��закончить��#��[  �� $��View/Data/logo.jpg��$
��Fill=�$��2��� -   $��Levels��$��2�����	#70000000$ 10��$��Stretch=�$��Stretch=�$y�	Collapsed=�.+��� -	   $��40��$��40��$	��Top=�$
 Hand��$��Right=�$��50q�#��[  
������ ���� $��View/Data/close.png���� -
   $��1��
���"�"�$��	0,0,0,120q�$��20(�$
 Hand��$��40��$	��150��#��[  �� -   $��2��
���"�"�$	��150��#��[  $
 Hand��$��20(�$��40���� -   $��3��
���"�"�$��	0,120,0,0q�$��20(�$
 Hand��$��40��$	��150��#��[   � -   $��Frame��$��1��  � Source$ View/Login.xaml?�$��
20,0,20,20q�  � NavigationUIVisibility$ Hidden=�