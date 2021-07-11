import dayjs from 'dayjs'
import Vue from 'vue'

// Services
import apiService from 'services/apiService.js';

// Handlers
import loadHandler from 'handlers/loadHandler.js';
import pagination from 'handlers/pagination.js';
import feedback from 'handlers/feedback';

// Components
import SortableColumn from './components/table/sortableColumn';
import DatePicker from './components/datepicker/datepicker';

// Directives
import OnSubmit from './directives/OnSubmit';
import SubmitValidator from './directives/SubmitValidator';


// Global Components
Vue.component('sortable-column', SortableColumn);
Vue.component('date-picker', DatePicker);

// Global Directives
Vue.directive('on-submit', OnSubmit);
Vue.directive('submit-validator', SubmitValidator);

// SET INTERNAL VUE VARIABLES / METHODS
Vue.prototype.$apiService = apiService;
Vue.prototype.$dayjs = dayjs;
Vue.prototype.$feedback = feedback;
Vue.prototype.$loadHandler = loadHandler;
Vue.prototype.$pagination = pagination;

// MAKE VUE A GLOBAL VARIABLE
window.Vue = Vue;