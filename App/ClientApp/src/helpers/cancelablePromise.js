import when from 'when';
import cancelable from 'when/cancelable';

const createCancelable = function() {
    return cancelable(when.defer(), console.log.bind(null, 'request canceled'));
};

export default () => {
    const deferred = createCancelable(),
        proto = Object.getPrototypeOf(deferred.promise);

    proto.abort = deferred.cancel;
    
    return deferred;
}