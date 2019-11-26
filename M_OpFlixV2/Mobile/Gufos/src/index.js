import {createAppContainer, createSwitchNavigator} from 'react-navigation';
import {createStackNavigator} from 'react-navigation-stack';
import {createBottomTabNavigator} from 'react-navigation-tabs';

import MainScreen from './pages/main';
import ProfileScreen from './pages/profile';
import SingInScreen from './pages/singin';

const AuthStack = createStackNavigator({
  Sing: {screen: SingInScreen},
});

const MainNavigator = createBottomTabNavigator({
  Main: {
    screen: MainScreen,
  },
  Profile: {
    screen: ProfileScreen,
  },
});

export default createAppContainer(
  createSwitchNavigator(
  {
    MainNavigator,
    AuthStack,
  }, {
    initialRouteName: 'AuthStack',
  },
),
);