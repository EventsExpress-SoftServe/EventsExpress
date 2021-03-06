import React, {Component} from 'react';
import { connect } from 'react-redux';
import EventItemView from '../components/event/event-item-view';
import eventStatusEnum from '../components/helpers/eventStatusEnum';
import Spinner from '../components/spinner';
import get_event, { 
    join, 
    leave, 
    resetEvent, 
    change_event_status, 
    approveUser, 
    deleteFromOwners, 
    promoteToOwner
    }
from '../actions/event-item-view';

class EventItemViewWrapper extends Component{
    componentWillMount(){    
        const { id } = this.props.match.params;
        this.props.get_event(id);
    }

    componentWillUnmount(){
        this.props.reset();
    }

    onJoin = () => {
        this.props.join(this.props.current_user.id, this.props.event.data.id);
    }

    onLeave = () => {
        this.props.leave(this.props.current_user.id, this.props.event.data.id);
    }

    onCancel = (reason, eventStatus) => {
        this.props.cancel(this.props.event.data.id, reason, eventStatus);
    }

    onUnCancel = (reason, eventStatus) => {
        this.props.unCancel(this.props.event.data.id, reason, eventStatus);
    }

    onApprove = (userId, buttonAction) => {
        this.props.approveUser(userId, this.props.event.data.id, buttonAction);
    }

    onDeleteFromOwners = (userId) => {
        this.props.deleteFromOwners(userId, this.props.event.data.id);
    }

    onPromoteToOwner = (userId) => {
        this.props.promoteToOwner(userId, this.props.event.data.id);
    }
    render(){   
        const { isPending } = this.props.event;
        return isPending
            ? <Spinner />
            : <EventItemView
                event={this.props.event}
                match={this.props.match} 
                onLeave={this.onLeave} 
                onJoin={this.onJoin}
                onCancel={this.onCancel}
                onUnCancel={this.onUnCancel}
                onApprove={this.onApprove}
                onDeleteFromOwners={this.onDeleteFromOwners}
                onPromoteToOwner={this.onPromoteToOwner}
                current_user={this.props.current_user}
            />
    }
}

const mapStateToProps = (state) => ({
    event: state.event, 
    current_user: state.user
});

const mapDispatchToProps = (dispatch) => ({
    get_event: (id) => dispatch(get_event(id)),
    join: (userId, eventId) => dispatch(join(userId, eventId)),
    leave: (userId, eventId) => dispatch(leave(userId, eventId)),
    cancel: (eventId, reason) => dispatch(change_event_status(eventId, reason, eventStatusEnum.Canceled)),
    unCancel: (eventId, reason) => dispatch(change_event_status(eventId, reason, eventStatusEnum.Active)),
    approveUser: (userId, eventId, buttonAction) => dispatch(approveUser(userId, eventId, buttonAction)),
    deleteFromOwners: (userId, eventId) => dispatch(deleteFromOwners(userId, eventId)),
    promoteToOwner: (userId, eventId) => dispatch(promoteToOwner(userId, eventId)),
    reset: () => dispatch(resetEvent())
});


export default connect(mapStateToProps, mapDispatchToProps)(EventItemViewWrapper);
