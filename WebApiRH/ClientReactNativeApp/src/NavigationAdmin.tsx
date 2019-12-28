import * as React from 'react';
import {
  View, Text, TouchableHighlight, Image, ScrollView, Button, ActivityIndicator, Alert, ColorPropType
} from 'react-native';
import { createAppContainer } from 'react-navigation';
import { createStackNavigator } from 'react-navigation-stack';
import { createBottomTabNavigator } from 'react-navigation-tabs';
import { createDrawerNavigator, DrawerItems } from 'react-navigation-drawer';
import {
  SearchHomeScreen, AddHomeScreen, NotificationScreen, ProfileScreen, AuthScreen, styles
} from './components';
import HomeScreen from './components/HomeTab/HomeScreen' 
import { SvgXml } from 'react-native-svg';
import { backArrow, login, addHome, home, searchHome, notif, menu, search } from './allSvg'
import { brown } from './constants';
import { useGlobal, store } from './store'


const BottomTab = createBottomTabNavigator({
  Home: {
    screen: HomeScreen,
    navigationOptions: { tabBarLabel: 'Дом' },
  },
  SearchHome: {
    screen: SearchHomeScreen,
    navigationOptions: { tabBarLabel: 'Поиск дома' },
  },
  Notification: {
    screen: NotificationScreen,
    navigationOptions: { tabBarLabel: 'Уведомления' },
  },
},
  {
    defaultNavigationOptions: ({ navigation }) => ({
      tabBarIcon: ({ focused, tintColor }) => {
        var { routeName } = navigation.state;
        return <SvgXml xml={
          routeName === 'Home' ? home : routeName === 'SearchHome' ?
          searchHome : routeName === 'Notification' ? notif : ''}
          style={styles.icon} fill={tintColor} />
      },
    }),
    tabBarOptions: {
      activeTintColor: brown,
      inactiveTintColor: 'gray',
    },
  }
);

const BottomTabStack = createStackNavigator({
  BottomTabStack: { screen: BottomTab },
},
  { headerMode: 'none', }
);


const MainDrawer = createDrawerNavigator({
  Tab: {
    screen: BottomTabStack,
    navigationOptions: {
      drawerLabel: ' ',
      drawerIcon: () =>
        <SvgXml xml={backArrow} width="20" height="20" style={styles.back} />
    }
  },
  Profile: {
    screen: ProfileScreen,
    navigationOptions: {
      drawerLabel: ' ',
      drawerIcon: () => <Image
        source={require('../icon/user1.png')}
        style={styles.imageIcon} />
    }
  },
  AddHome: {
    screen: AddHomeScreen,
    navigationOptions: {
      drawerLabel: 'Добавить дом',
      drawerIcon: () => <SvgXml xml={addHome} style={styles.icon} />
    }
  },
  Auth: {
    screen: AuthScreen,
    navigationOptions: {
      drawerLabel: 'Выход',
      drawerIcon: () => <SvgXml xml={login} style={styles.icon} />
    },
  },
}, {
  //initialRouteName: 'Tab',
  drawerBackgroundColor: brown,
  //drawerPosition: 'right',
  drawerType: 'front',
  drawerWidth: 220,
  swipeDistanceThreshold: 100,
  contentOptions: {
    itemConteinerStyle: {
      marginVertical: 10
    }
  }
});

const MainNavigation = createStackNavigator(
  {
    Drawer: MainDrawer,
  },
  {
    initialRouteName: 'Drawer',
    headerMode: 'none',
  }
);

export default createAppContainer(MainNavigation);
