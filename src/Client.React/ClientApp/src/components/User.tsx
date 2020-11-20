import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { ApplicationState } from '../store';
import { actionCreators } from '../store/Counter';
import * as UserStore from '../store/User';

type UserProps =
    UserStore.UserState &
    RouteComponentProps<{}>;

class User extends React.PureComponent<UserProps> {
    public render() {
        return (
            <React.Fragment>
                <h1>User</h1>

                <p aria-live="polite">Name: <strong>{this.props.currentUser.name}</strong></p>
            </React.Fragment>
        );
    }
};

export default connect(
    (state: ApplicationState) => state.user,
    UserStore.actionCreators
)(User)
