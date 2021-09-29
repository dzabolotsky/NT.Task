import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import {WeatherForecast} from './components/pages';


import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={WeatherForecast} />       
    </Layout>
);
