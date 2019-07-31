﻿import React, { Component } from 'react';
import { connect } from 'react-redux';
import CommentList from '../components/comment/comment-list';
import Spinner from '../components/spinner';
import get_comments from '../actions/comment-list';


class CommentListWrapper extends Component {

    componentWillMount = () => this.props.get_comments(this.props.eventId);

    render() {

        const { data, isPending, isError } = this.props.comments;
        const spinner = isPending ? <Spinner /> : null;
        const content = !isPending ? <CommentList data_list={data} /> : null;

        return <>
            {spinner}
            {content}
        </>
    }
}

const mapStateToProps = state => ({
    comments: state.comments,
    eventId: state.event.data.id
});

const mapDispatchToProps = (dispatch) => {
    return {
        get_comments: (value) => dispatch(get_comments(value))
    }
};

export default connect(mapStateToProps, mapDispatchToProps)(CommentListWrapper);