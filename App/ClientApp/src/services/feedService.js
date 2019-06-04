import cancelablePromise from '../helpers/cancelablePromise';

const feedAPI = 'api/FeedData';

export default {
    returnsFeedInfo: (queryString) => {
        const deferred = cancelablePromise();
        
        fetch(`${feedAPI}/ReturnsFeedInfo` + (queryString ? `?${queryString}` : ''))
            .then(response => response.json())
            .then((response) => deferred.resolve(response), deferred.reject);

        return deferred.promise;
    }
}