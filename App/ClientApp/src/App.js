import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Orgs/Layout/Layout';
import { Home } from './components/Pages/Home/Home';
import { FeedInfo } from './components/Pages/FeedInfo/FeedInfo';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/feed-info' component={FeedInfo} />
      </Layout>
    );
  }
}
