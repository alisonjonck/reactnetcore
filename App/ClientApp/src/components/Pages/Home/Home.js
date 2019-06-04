import React, { Component } from 'react';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

import "./Home.css";

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Bem vindo ao FeedInfo!</h1>
        <p>Bem vindo ao App FeedInfo, construído com:</p>
        <ul>
          <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
          <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
          <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
        </ul>
        <div>
          <h2>Analise agora os resultados do feed:</h2>
          <NavLink tag={Link} className="text-go-now" to="/feed-info">Analisar Feed</NavLink>
        </div>
      </div>
    );
  }
}
